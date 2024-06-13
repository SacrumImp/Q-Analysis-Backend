using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using q_analysis_backend.Extentions;
using q_analysis_backend.Models.Controllers.Analysis.Input;
using q_analysis_backend.Models.Controllers.Analysis.Input.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_backend.Providers;

namespace q_analysis_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {

        private readonly ILogger<AnalysisController> _logger;
        private readonly IQAnalysisProvider _qAnalysisProvider;

        public AnalysisController(
            ILogger<AnalysisController> logger,
            IQAnalysisProvider qAnalysisProvider
        )
        {
            _logger = logger;
            _qAnalysisProvider = qAnalysisProvider;
        }

        [HttpPost]
        public ActionResult<List<AnalysisResult>> Get([FromBody] SimplicesInput simplicesInput)
        {
            var invalid = simplicesInput.Simplices.Any(simplex => simplex.Relations.Any(relation => !relation.IsValid()));
            if (invalid)
            {
                return BadRequest("Errors were found in the descriptions of the relations");
            }

            var method = EnumExtentions.GetEnumValueOrDefault(simplicesInput.EccentricityCalculationMethod, EccentricityCalculationMethod.Casti);
            var data = simplicesInput.GetStructures().Select(entry =>
            {
                return _qAnalysisProvider.PerformQCalculations(entry.Key, entry.Value, method);
            }).ToList();
            var results = data.Select(result => {
                return new AnalysisResult()
                {
                    Keys = result.Key.Keys,
                    Result = new CalculationResult()
                    {
                        Dimension = result.Vector.Dimension,
                        VectorElements = result.Vector.VectorElements,
                        Eccentricities = result.Eccentricities,
                    }
                };
            }).ToList();

            if (data.Count > 1)
            {
                var aggregatedResult = _qAnalysisProvider.AggregateResults(data);
                results.Add(aggregatedResult);
            }

            return Ok(results);
        }
    }
}

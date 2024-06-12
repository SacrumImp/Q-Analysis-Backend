using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using q_analysis_backend.Extentions;
using q_analysis_backend.Models.Controllers.Analysis.Input;
using q_analysis_backend.Models.Controllers.Analysis.Input.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Primitives;
using q_analysis_backend.Models.Controllers.Analysis.Result;
using q_analysis_backend.Providers;
using q_analysis_math;

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

            var results = new List<AnalysisResult>();
            var data = simplicesInput.GetStructures();
            foreach (KeyValuePair<SplitKey, Simplex[]> entry in data)
            {
                var vector = _qAnalysisProvider.GetQVector(entry.Value);
                var method = EnumExtentions.GetEnumValueOrDefault(simplicesInput.EccentricityCalculationMethod, EccentricityCalculationMethod.Casti);
                var eccentricities = _qAnalysisProvider.GetEccentricities(entry.Value, vector, method);
                results.Add(new AnalysisResult()
                {
                    Keys = entry.Key.Keys,
                    Result = new CalculationResult()
                    {
                        Dimension = vector.Dimension,
                        VectorElements = vector.VectorElements,
                        Eccentricities = eccentricities
                    }
                });
            }

            return Ok(results);
        }
    }
}

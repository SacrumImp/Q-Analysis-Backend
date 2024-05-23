using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using q_analysis_backend.Extentions;
using q_analysis_backend.Models.Controllers.Analysis;
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
        public ActionResult<CalculationResult> Get([FromBody] SimplicesInput simplicesInput)
        {

            var invalid = simplicesInput.Simplices.Any(simplex => simplex.Relations.Any(relation => !relation.IsValid()));
            if (invalid)
            {
                return BadRequest("Errors were found in the descriptions of the links");
            }

            var simplices = simplicesInput.Simplices.Select(simplexInput => simplexInput.GetSimplex).ToArray();
            var vector = _qAnalysisProvider.GetQVector(simplices);
            var method = EnumExtentions.GetEnumValueOrDefault(simplicesInput.EccentricityCalculationMethod, EccentricityCalculationMethod.Casti);
            var eccentricities = _qAnalysisProvider.GetEccentricities(simplices, vector, method);

            return Ok(new CalculationResult()
            {
                Dimension = vector.Dimension,
                VectorElements = vector.VectorElements,
                eccentricities = eccentricities
            });
        }
    }
}

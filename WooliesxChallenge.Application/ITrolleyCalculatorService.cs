using System.Threading.Tasks;
using WooliesxChallenge.Domain;

namespace WooliesxChallenge.Application
{
    public interface ITrolleyCalculatorService
    {
        public decimal CalculateTotal(TrolleyRequest trolleyRequest);
    }
}

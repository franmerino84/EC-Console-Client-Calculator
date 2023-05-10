using EC.Console.Client.Calculator.Presentation.Processors;
using EC.Console.Client.Calculator.Presentation.Processors.Factory;
using EC.Console.Client.Calculator.Test.Helpers;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

namespace EC.Console.Client.Calculator.Test.Presentation.Processors.Factory
{

    [TestFixture]
    [Category(Category.Unit)]
    public class OperationProcessorFactoryTests
    {
        private OperationProcessorFactory _factory;
        private AdditionProcessor _addition;
        private DivisionProcessor _division;
        private MultiplicationProcessor _multiplication;
        private SquareRootProcessor _squareRoot;
        private SubtractionProcessor _subtraction;
        private JournalProcessor _journal;

        [SetUp]
        public void SetUp()
        {

            _addition = new AdditionProcessor(null);
            _division = new DivisionProcessor(null);
            _multiplication = new MultiplicationProcessor(null);
            _squareRoot = new SquareRootProcessor(null);
            _subtraction = new SubtractionProcessor(null);
            _journal = new JournalProcessor(null);

            _factory = new OperationProcessorFactory(_addition, _division, _multiplication, _squareRoot, _subtraction, _journal);
        }

        [Test]
        public void Build_Sum_Returns_AdditionProcessor()
        {
            Assert.That(_factory.Build("sum"), Is.EqualTo(_addition));
        }

        [Test]
        public void Build_Div_Returns_DivisionProcessor()
        {
            Assert.That(_factory.Build("div"), Is.EqualTo(_division));
        }

        [Test]
        public void Build_Mul_Returns_MultiplicationProcessor()
        {
            Assert.That(_factory.Build("mul"), Is.EqualTo(_multiplication));
        }

        [Test]
        public void Build_Sqr_Returns_SquareRootProcessor()
        {
            Assert.That(_factory.Build("sqr"), Is.EqualTo(_squareRoot));
        }

        [Test]
        public void Build_Sub_Returns_SubtractionProcessor()
        {
            Assert.That(_factory.Build("sub"), Is.EqualTo(_subtraction));
        }

        [Test]
        public void Build_Journal_Returns_JournalProcessor()
        {
            Assert.That(_factory.Build("journal"), Is.EqualTo(_journal));
        }

        [Test]
        public void Build_Other_Throws_OperationNotImplementedException()
        {
            Assert.Throws<OperationNotImplementedException>(()=>_factory.Build("other"));
        }
    }
}

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

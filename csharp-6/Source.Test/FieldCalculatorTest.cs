using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Codenation.Challenge
{
    public class FieldCalculatorTest
    {
        const string CLASS_FULL_NAME = "Codenation.Challenge.FieldCalculator";
        const string INTERFACE_FULL_NAME = "Codenation.Challenge.ICalculateField";
        const string ASSEMBLY_NAME = "Source";
        const string ADDITION_METHOD = "Addition";
        const string SUBTRACTION_METHOD = "Subtraction";
        const string TOTAL_METHOD = "Total";

        /// When a class C implements an interface I, to find the method MC on class that 
        /// correspond the method MI of that interface, you must use the GetInterfaceMap
        private MethodInfo GetImplementationMethod(Type sourceInterface, Type sourceClass, string methodName)
        {
            var map = sourceClass.GetInterfaceMap(sourceInterface);
            var methodIndex = map.InterfaceMethods.ToList().FindIndex(x => x.Name == methodName);
            return map.TargetMethods[methodIndex];
        }

        [Fact]
        public void Should_Exists_The_Class()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var expected = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Should_Implements_ICalculateField_Interface()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            var actual = assembly.GetType(CLASS_FULL_NAME);
            Assert.NotNull(actual);
            var interfaces = actual.GetInterfaces().Select(x => x.FullName).ToList();
            Assert.Contains(INTERFACE_FULL_NAME, interfaces);
        }

        [Fact]
        public void TestAddition()
        {
            var calculator = new FieldCalculator();

            var teste = new TestClass();
            teste.SetPrimeiroValor(10);
            teste.SetSegundoValor(5);
            teste.SetTerceiroValor(-15);
            Assert.Equal(0, calculator.Addition(teste));
        }

        [Fact]
        public void AdditionShouldReturnZero()
        {
            var calculator = new FieldCalculator();
            var teste = new Object();
            Assert.Equal(0, calculator.Addition(teste));
        }

        [Fact]
        public void SubtractionShouldReturnZero()
        {
            var calculator = new FieldCalculator();
            var teste = new Object();
            Assert.Equal(0, calculator.Subtraction(teste));
        }

        [Fact]
        public void TestSubtraction()
        {
            var calculator = new FieldCalculator();

            var teste = new TestClass();
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(5);
            //teste.SetTerceiroValor(-15);
            Assert.Equal(5, calculator.Subtraction(teste));
        }

        [Fact]
        public void TestTotalAddition()
        {
            var calculator = new FieldCalculator();

            var teste = new TestClass();
            teste.SetPrimeiroValor(-10);
            teste.SetSegundoValor(5);
            //teste.SetTerceiroValor(-15);
            Assert.Equal(-5, calculator.Total(teste));
        }

        [Fact]
        public void TestTotal()
        {
            var calculator = new FieldCalculator();

            var teste = new TestClass();
            teste.SetPrimeiroValor(-10);
            teste.SetSegundoValor(20);
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(20);
            Assert.Equal(0, calculator.Total(teste));
        }

        [Fact]
        public void TestTotalSubtraction()
        {
            var calculator = new FieldCalculator();

            var teste = new TestClass();
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(20);
            Assert.Equal(-10, calculator.Total(teste));
        }
    }
}
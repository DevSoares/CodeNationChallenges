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
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);
            var teste = new TestClass();

            teste.SetPrimeiroValor(10);
            teste.SetSegundoValor(5);
            teste.SetTerceiroValor(15);

            var objArray = new Object[] { teste };

            Assert.Equal((decimal)30, calculator.GetType().InvokeMember(ADDITION_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void AdditionShouldReturnZero()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);
            var objArray = new object[] { new Object() };

            Assert.Equal((decimal)0, calculator.GetType().InvokeMember(ADDITION_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void SubtractionShouldReturnZero()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);
            var objArray = new object[] { new Object() };

            Assert.Equal((decimal)0, calculator.GetType().InvokeMember(SUBTRACTION_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void TestSubtraction()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);

            var teste = new TestClass();
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(5);
            var objArray = new object[] { teste };

            Assert.Equal((decimal)5, calculator.GetType().InvokeMember(SUBTRACTION_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void TestTotalAddition()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);

            var teste = new TestClass();
            teste.SetPrimeiroValor(-10);
            teste.SetSegundoValor(5);
            var objArray = new object[] { teste };

            Assert.Equal((decimal)-5, calculator.GetType().InvokeMember(TOTAL_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void TestTotal()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);

            var teste = new TestClass();
            teste.SetPrimeiroValor(-10);
            teste.SetSegundoValor(20);
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(20);
            var objArray = new object[] { teste };

            Assert.Equal((decimal)0, calculator.GetType().InvokeMember(TOTAL_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }

        [Fact]
        public void TestTotalSubtraction()
        {
            var assembly = Assembly.Load(ASSEMBLY_NAME);
            Type actual = assembly.GetType(CLASS_FULL_NAME);
            var calculator = Activator.CreateInstance(actual);

            var teste = new TestClass();
            teste.SetQuartoValor(-10);
            teste.SetQuintoValor(20);
            var objArray = new object[] { teste };

            Assert.Equal((decimal)-10, calculator.GetType().InvokeMember(TOTAL_METHOD, BindingFlags.InvokeMethod, null, calculator, objArray));
        }
    }
}
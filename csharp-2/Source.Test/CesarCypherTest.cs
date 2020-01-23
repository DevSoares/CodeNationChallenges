using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0"));
        }
        
        [Fact]
        public void Should_Not_Accept_Special_Char_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Crypt("a0ç"));
        }

        [Fact]
        public void Should_Be_Lower_When_Crypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0".ToUpper()));
        }

        [Fact]
        public void Should_Be_Lower_When_DeCrypt()
        {
            var cypher = new CesarCypher();
            Assert.Equal("a1b2c3d4e5f6g7h8i9j0", cypher.Decrypt("d1e2f3g4h5i6j7k8l9m0".ToUpper()));
        }

    }
}

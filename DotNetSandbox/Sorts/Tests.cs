using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GLibrary.Sorts;

namespace DotNetSandbox.Sorts
{
    public class ImplementsIEnum : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return null;
        }
        public ImplementsIEnum()
        {
            Console.Write(1);
        }
    }

    public class Tests
    {
        [Fact]
        public void Test()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var interaces = types[6].GetInterfaces();
            var con = types[6].GetConstructor(Type.EmptyTypes);
            var sut = Activator.CreateInstance(types[6]);
            Assert.NotNull(sut);
            Assert.Equal(typeof(ImplementsIEnum), sut.GetType());
        }

        [Fact]
        public void GetSubtypesOfType()
        {
            var sorters = ArrayHelpers.GetSubtypesOfType<ISort>();
            Assert.NotEmpty(sorters);
        }

        [Theory]
        [InlineData(12)]
        public void DataGenerator_should_return_array_of_size(int len)
        {
            var arr = DataGenerator.GenerateRandomArray(len);
            Assert.Equal(len, arr.Length);
        }

        //if (!ArrayAssertions.IsInSortedOrder<int>(intArray))
        //    {
        //        throw new SystemException("Is not ordered!");
        //    }

        //    ArrayPrint.Print(intArray);
        //    ArrayPrint.Print(negativeArray);
    }
}


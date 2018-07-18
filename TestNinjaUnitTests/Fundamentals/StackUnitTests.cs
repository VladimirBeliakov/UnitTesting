using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class StackUnitTests
    {
        [Test]
        public void Push_NullObject_ThrowsEx()
        {
            // Arrange
            var stack = StackFactory();
            string obj = null;

            // Act
            TestDelegate del = () => stack.Push(obj);

            // Assert
            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void Push_ValidObject_AddsToList()
        {
            // Arrange
            var stack = StackFactory();
            string obj = "any string";
            var count = stack.Count;

            // Act
            stack.Push(obj);

            // Assert
            Assert.AreEqual(count + 1, stack.Count);
        }

        [Test]
        public void Pop_EmptyList_ThrowsEx()
        {
            // Arrange
            var stack = StackFactory();

            // Act
            TestDelegate del = () => stack.Pop();

            // Assert
            Assert.Throws<InvalidOperationException>(del);

        }

        [Test]
        public void Pop_NotEmptyList_RemovesFromList()
        {
            // Arrange
            var stack = StackFactory();
            var obj = "any string";
            stack.Push(obj);
            var count = stack.Count;

            // Act
            stack.Pop();

            // Assert
            Assert.AreEqual(count - 1, stack.Count);
        }

        [Test]
        public void Pop_NotEmptyList_ReturnsRemovedItem()
        {
            // Arrange
            var stack = StackFactory();
            var obj = "any string";
            stack.Push(obj);

            // Act
            var result = stack.Pop();

            // Assert
            Assert.AreEqual(obj, result);
        }

        [Test]
        public void Peek_EmptyList_ThrowsEx()
        {
            // Arrange
            var stack = StackFactory();

            // Act
            TestDelegate del = () => stack.Peek();

            // Assert
            Assert.Throws<InvalidOperationException>(del);

        }

        [Test]
        public void Peek_NotEmptyList_ReturnsLastItem()
        {
            // Arrange
            var stack = StackFactory();
            var obj1 = "first item";
            var obj2 = "second item";
            stack.Push(obj1);
            stack.Push(obj2);

            // Act
            var result = stack.Peek();

            // Assert
            Assert.AreEqual(obj2, result);
        }

        private TestNinja.Fundamentals.Stack<string> StackFactory()
        {
            return new TestNinja.Fundamentals.Stack<string>();
        }
    }
}

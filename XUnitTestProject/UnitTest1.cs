using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XUnitTestProject
{
    // This is the main class, it simulates an object with a position in x,y and size.
    public class MovingObject
    {
        public int positionX = 0;
        public int positionY = 0;
        public string name = "";

        private int originalX = 0;
        private int originalY = 0;

        public MovingObject(int initialX, int initialY, string initialName)
        {
            positionX = initialX;
            originalX = initialX;
            positionY = initialY;
            originalY = initialY;
            name = initialName;
        }

        public void moveLeft (int steps = 0)
        {
            positionX -= Math.Max(steps, 1);
        }

        public void moveRight(int steps = 0)
        {
            positionX += Math.Max(steps, 1);
        }


        public void moveDown(int steps = 0)
        {
            positionY -= Math.Max(steps, 1);
        }

        public void moveUp(int steps = 0)
        {
            positionY += Math.Max(steps, 1);
        }


        public bool hasMoved()
        {
            return positionX != originalX || positionY != originalY;
        }

    }


    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Testing if object exists
            MovingObject test = new MovingObject(0, 0, "");
            Assert.NotNull(test);
        }

        [Fact]
        public void Test2()
        {
            // Testing construction
            MovingObject test = new MovingObject(0, 0, "");
            Assert.IsType<MovingObject>(test);
        }


        [Fact]
        public void Test3()
        {
            // Testing if methods change the position on X or Y with equal
            MovingObject test = new MovingObject(0, 0, "");
            test.moveLeft(5);
            test.moveUp(5);
            Assert.Equal(-5, test.positionX);
            Assert.Equal(5, test.positionY);
        }

        [Fact]
        public void Test4()
        {
            // Testing if object has moved from original position
            MovingObject test = new MovingObject(0, 0, "");
            test.moveUp(5);
            test.moveRight(5);
            Assert.True(test.hasMoved());
        }


        [Fact]
        public void Test5()
        {
            // Testing if object has NOT moved from original position
            MovingObject test = new MovingObject(0, 0, "");
            test.moveUp(5);
            test.moveRight(5);
            test.moveDown(5);
            test.moveLeft(5);
            Assert.False(test.hasMoved());
        }


        [Fact]
        public void Test6()
        {
            // Testing if object name ends with substring
            MovingObject test = new MovingObject(0, 0, "pikachu");
            Assert.EndsWith("chu", test.name);
        }

        [Fact]
        public void Test7()
        {
            // Testing if object name starts with substring
            MovingObject test = new MovingObject(0, 0, "pikachu");
            Assert.StartsWith("pika", test.name);
        }

        [Fact]
        public void Test8()
        {
            // Testing if 2 instances of the class would not create same entity
            MovingObject obj1 = new MovingObject(0, 0, "");
            MovingObject obj2 = new MovingObject(0, 0, "");
            Assert.NotSame(obj1, obj2);
        }

        [Fact]
        public void Test9()
        {
            // Testing if copying an object would result on same entity
            MovingObject obj1 = new MovingObject(0, 0, "");
            MovingObject obj2 = obj1;
            Assert.Same(obj1, obj1);
        }


        [Fact]
        public void Test10()
        {
            // Testing if object is Assigned from a class
            MovingObject test = new MovingObject(0, 0, "pikachu");
            Assert.IsAssignableFrom<MovingObject>(test);
        }

    }

}

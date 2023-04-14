using Assignment3.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    internal class SLLTest
    {
        private SLL sll;
        [SetUp]
        public void SetUp()
        {
            sll = new SLL();

        }
        [TearDown]
        public void TearDown()
        {
            sll.Clear();
        }
        [Test]
        public void TestEmpty()
        {
            sll.IsEmpty();
            Assert.Pass();
        }
        [Test]
        public void TestPrepend()
        {
            sll.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.AddFirst(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));

            Assert.AreEqual(sll.Head.value.Id, 2);
            Assert.AreEqual(sll.Head.value.Name, "Joe Schmoe");

        }
        public void TestAppend()
        {
            sll.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));

            Assert.AreEqual(sll.Head.Next.value.Id, 2);
            Assert.AreEqual(sll.Head.Next.value.Name, "Joe Schmoe");
        }

        [Test]
        public void TestAppendIndex()
        {
            sll.AddFirst(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            sll.Add(new User(1, "Joe Blow", "jblow@gmail.com", "password"), 1);
            sll.Add(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"), 2);
            var expected = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");

            Assert.AreEqual(expected, sll.GetValue(0));
        }

        [Test]
        public void TestReplaced()
        {
            sll.AddFirst(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            sll.Add(new User(1, "Joe Blow", "jblow@gmail.com", "password"), 1);
            sll.Replace(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"), 1);
            var expected = (new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            Assert.AreEqual(sll.GetValue(1), expected);
        }

        [Test]
        public void TestRemoveFirst()
        {
            sll.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.AddFirst(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            sll.RemoveFirst();

            Assert.AreEqual(sll.Head.value.Id, 1);
        }

        [Test]
        public void TestRemoveLast()
        {
            sll.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            sll.RemoveLast();

            Assert.AreEqual(sll.Head.value.Id, 1);
        }

        [Test]
        public void TestRemove()
        {
            sll.AddFirst(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "password"));
            sll.Add(new User(1, "Joe Blow", "jblow@gmail.com", "password"), 1);
            sll.Add(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"), 2);
            sll.Remove(1);
            var expected = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");

            Assert.AreEqual(expected, sll.GetValue(1));
        }

        [Test]
        public void TestFoundAndRetrieve()
        {
            sll.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.Add(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"), 1);
            sll.Add(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"), 2);
            var expected = sll.IndexOf(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));

            Assert.AreEqual(1, expected);
        }

        [Test]
        public void TestReverse()
        {
            sll.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            sll.AddFirst(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            sll.AddFirst(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            sll.Reverse();

            Assert.AreEqual(sll.Head.value.Id, 1);

        }

    }
}

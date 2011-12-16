using CommandInterpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotDriveProtocol;
using RobotCtrl;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System;
using System.Diagnostics;

namespace CommandInterpreterTest
{
    [TestClass()]
    public class InterpreterTest
    {


        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //    RunMode actualMode = Constants.IsWinCE ? RunMode.Real : RunMode.Virtual;
        //    Drive drv = new Drive(actualMode);
        //    Robot r = new Robot(actualMode);
        //    World.Robot = r;
        //}

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for InterpretMessage
        ///</summary>
        [TestMethod()]
        public void InterpretMessageTest()
        {
            Interpreter target = new Interpreter(); // TODO: Initialize to an appropriate value
            string message = string.Empty; // TODO: Initialize to an appropriate value
            target.InterpretMessage(message);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Interpreter Constructor
        ///</summary>
        [TestMethod()]
        public void InterpreterConstructorTest()
        {
            Interpreter target = new Interpreter();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for InterpretCommand
        ///</summary>
        [TestMethod()]
        public void InterpretCommandTest()
        {
            RunMode actualMode = Constants.IsWinCE ? RunMode.Real : RunMode.Virtual;
            Drive drv = new Drive(actualMode);
            Robot r = new Robot(actualMode);
            World.Robot = r;

            Interpreter interpreter = new Interpreter();
            //Interpreter_Accessor target = new Interpreter_Accessor(); // TODO: Initialize to an appropriate value
            Command cmd = new Command(); // TODO: Initialize to an appropriate value
            cmd.Method = "RunLine";//RunLine(float length, float speed, float acceleration)
            //cmd.Parameters.Add(new CommandParam() { Type = typeof(float), Parameter = 1 });
            //cmd.Parameters.Add(new CommandParam() { Type = typeof(float), Parameter = 1 });
            //cmd.Parameters.Add(new CommandParam() { Type = typeof(float), Parameter = 1 });
            ////cmd.Parameters.Add(new CommandParam() { Type = typeof(float), Parameter = 1 });
            
            //interpreter.InterpretCommand(cmd);

            //target.InterpretCommand(cmd);

            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void CommandTest()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Command));
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
            Command cmd = new Command(); // TODO: Initialize to an appropriate value
            cmd.Method = "RunLine";//RunLine(float length, float speed, float acceleration)
            cmd.Parameters.Add(1.0f);
            cmd.Parameters.Add(1.0f);
            cmd.Parameters.Add(1.0f);

            serializer.Serialize(xmlWriter, cmd);
            xmlWriter.Flush();

            Debug.WriteLine(stringWriter.ToString());

            //XmlSerializer serializer = new XmlSerializer(typeof(Command));
            StringReader stringReader = new StringReader(stringWriter.ToString());
            XmlReader xmlReader = XmlReader.Create(stringReader);
            if (serializer.CanDeserialize(xmlReader))
            {
                object o = serializer.Deserialize(xmlReader);
                if (o is Command)
                {
                    Command cmdDeserialized = (Command)o;
                    Debug.WriteLine(cmdDeserialized.ToString());
                }
            }
        }
    }
}

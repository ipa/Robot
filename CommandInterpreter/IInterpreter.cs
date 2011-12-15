using System;
namespace CommandInterpreter
{
    public interface IInterpreter
    {
        void InterpretMessage(string message);
    }
}

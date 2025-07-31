using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Factory.Tools
{
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}

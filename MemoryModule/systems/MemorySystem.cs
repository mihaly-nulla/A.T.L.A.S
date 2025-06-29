using A.T.L.A.S.MemoryModule.components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.T.L.A.S.MemoryModule.systems
{
    public class MemorySystem
    {
        private SemanticMemory semanticMemory;
        public MemorySystem()
        {
            semanticMemory = new SemanticMemory("empty");
        }
    }
}

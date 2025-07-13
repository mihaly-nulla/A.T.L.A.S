using A.T.L.A.S.Mind.MemoryModule.components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.T.L.A.S.Mind.MemoryModule.systems
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

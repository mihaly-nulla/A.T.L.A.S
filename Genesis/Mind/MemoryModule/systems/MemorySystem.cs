using Genesis.Mind.MemoryModule.components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Mind.MemoryModule.systems
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

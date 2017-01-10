using System;

namespace Entitas.CodeGenerator {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = true)]
    public class ContextAttribute : Attribute {

        public readonly string poolName;

        // TODO Try to use this again as soon Unity updates to newer mono
        //public PoolAttribute(string poolName = CodeGenerator.DEFAULT_POOL_NAME) {
        public ContextAttribute(string poolName = "Pool") {
            this.poolName = poolName;
        }
    }
}
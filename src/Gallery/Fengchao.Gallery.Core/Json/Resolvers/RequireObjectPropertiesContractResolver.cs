using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Fengchao.Gallery.Core.Json.Resolvers
{
    /// <summary>
    /// Used by <see cref="JsonSerializer"/> to resolve a <see cref="JsonContract"/> of which 
    /// <see cref="JsonObjectContract.ItemRequired"/> is set to always required for a given <see cref="Type"/>.
    /// </summary>
    public class RequireObjectPropertiesContractResolver : DefaultContractResolver
    {
        private readonly Required _itemRequired;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequireObjectPropertiesContractResolver"/>.
        /// </summary>
        /// <param name="itemRequired">Indicating whether all properties are required.</param>
        public RequireObjectPropertiesContractResolver(Required itemRequired)
        {
            _itemRequired = itemRequired;
        }

        /// <inheritdoc/>
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.ItemRequired = _itemRequired;
            return contract;
        }
    }
}

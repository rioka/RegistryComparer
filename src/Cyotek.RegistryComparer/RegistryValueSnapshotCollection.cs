using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Cyotek.RegistryComparer
{
  public class RegistryValueSnapshotCollection : KeyedCollection<string, RegistryValueSnapshot>
  {
    #region Constructors

    public RegistryValueSnapshotCollection()
      : base(StringComparer.Ordinal)
    { }

    public RegistryValueSnapshotCollection(RegistryKeySnapshot parent)
      : this()
    {
      this.Parent = parent;
    }

    #endregion

    #region Properties

    [JsonIgnore]
    public RegistryKeySnapshot Parent { get; set; }

    public RegistryValueSnapshotCollection ValueSnapshotCollection { get; set; }

    #endregion

    #region Methods

    public bool TryGetValue(string key, out RegistryValueSnapshot value)
    {
      IDictionary<string, RegistryValueSnapshot> dictionary;

      dictionary = this.Dictionary;
      value = null;

      return dictionary != null && dictionary.TryGetValue(key, out value);
    }

    protected override string GetKeyForItem(RegistryValueSnapshot item)
    {
      return item.Name;
    }

    #endregion
  }
}

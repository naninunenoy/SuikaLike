using System.Collections.Generic;
using UnityEngine;

namespace SuikaLike.GameFeatures;

public class SuikaContainer : ISuikaIdResolver
{
    Dictionary<SuikaId, SuikaObject> _dictionary = new();

    public void Add(SuikaObject suika)
    {
        _dictionary.Add(suika.Id, suika);
    }

    public void Remove(SuikaId id)
    {
        if (_dictionary.ContainsKey(id))
        {
            Object.Destroy(_dictionary[id].GameObject);
            _dictionary.Remove(id);
        }
    }

    public bool TryGetById(SuikaId id, out SuikaObject suika)
    {
        return _dictionary.TryGetValue(id, out suika);
    }
}

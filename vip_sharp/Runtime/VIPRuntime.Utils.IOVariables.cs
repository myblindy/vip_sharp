using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    partial class VIPRuntime
    {
        private static void AddIOVariable<T>(string key, T var)
        {
            if (!Instance.VIPSystemClass.IOVariables.ContainsKey(key))
                Instance.VIPSystemClass.IOVariables.Add(key, var);
        }

        private static void BuildIOVariables(IEnumerable<UnmanagedDefinition> defs)
        {
            foreach (var item in defs)
                switch (item.Type)
                {
                    case UnmanagedType.Char:
                        if (item.ArrayIndex1.HasValue)
                            if (item.ArrayIndex2.HasValue)
                                AddIOVariable(item.Name, new BipolarArray<char>(item.ArrayIndex1.Value, item.ArrayIndex2.Value));
                            else
                                AddIOVariable(item.Name, new BipolarArray<char>(item.ArrayIndex1.Value));
                        else
                            AddIOVariable(item.Name, new char());
                        break;
                    case UnmanagedType.Double:
                        if (item.ArrayIndex1.HasValue)
                            if (item.ArrayIndex2.HasValue)
                                AddIOVariable(item.Name, new BipolarArray<double>(item.ArrayIndex1.Value, item.ArrayIndex2.Value));
                            else
                                AddIOVariable(item.Name, new BipolarArray<double>(item.ArrayIndex1.Value));
                        else
                            AddIOVariable(item.Name, new double());
                        break;
                    case UnmanagedType.Int:
                        if (item.ArrayIndex1.HasValue)
                            if (item.ArrayIndex2.HasValue)
                                AddIOVariable(item.Name, new BipolarArray<int>(item.ArrayIndex1.Value, item.ArrayIndex2.Value));
                            else
                                AddIOVariable(item.Name, new BipolarArray<int>(item.ArrayIndex1.Value));
                        else
                            AddIOVariable(item.Name, new int());
                        break;
                    case UnmanagedType.Short:
                        if (item.ArrayIndex1.HasValue)
                            if (item.ArrayIndex2.HasValue)
                                AddIOVariable(item.Name, new BipolarArray<short>(item.ArrayIndex1.Value, item.ArrayIndex2.Value));
                            else
                                AddIOVariable(item.Name, new BipolarArray<short>(item.ArrayIndex1.Value));
                        else
                            AddIOVariable(item.Name, new short());
                        break;
                    case UnmanagedType.Single:
                        if (item.ArrayIndex1.HasValue)
                            if (item.ArrayIndex2.HasValue)
                                AddIOVariable(item.Name, new BipolarArray<float>(item.ArrayIndex1.Value, item.ArrayIndex2.Value));
                            else
                                AddIOVariable(item.Name, new BipolarArray<float>(item.ArrayIndex1.Value));
                        else
                            AddIOVariable(item.Name, new float());
                        break;
                    default:
                        throw new InvalidOperationException();
                }
        }
    }
}

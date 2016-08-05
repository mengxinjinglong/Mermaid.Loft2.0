using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace ConsoleApplication2._0
{
    public enum OperateObjectType
    {
        LocalMachine,
        Users,
        CurrentUser,
        Root,
        CurrentConfig
    }
    public class RegistryUtil
    {
        private RegistryUtil()
        {
        }
        /// <summary>
        /// 检查对应的值是否存在
        /// </summary>
        /// <param name="path">注册表路径</param>
        /// <param name="subKey">注册表子健</param>
        /// <param name="registryKey">注册表键</param>
        /// <param name="value">注册表值</param>
        /// <param name="operateObject">查找注册表的根目录</param>
        /// <returns></returns>
        public static bool ExistKey(string path, string subKey, string registryKey, string value = null,
            OperateObjectType operateObject = OperateObjectType.LocalMachine)
        {
            RegistryKey key = null;
            try
            {
                if (operateObject.ToString().Equals("LocalMachine"))
                {
                    key = Registry.LocalMachine.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Users"))
                {
                    key = Registry.Users.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentUser"))
                {
                    key = Registry.CurrentUser.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Root"))
                {
                    key = Registry.ClassesRoot.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentConfig"))
                {
                    key = Registry.CurrentConfig.OpenSubKey(path, true);
                }
                if (key == null) return false;
                var subItem = key.OpenSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (subItem == null)
                {
                    return false;
                }
                var keyValue = subItem.GetValue(registryKey);
                if (value == null)
                    return keyValue != null;
                return !(keyValue == null || keyValue.ToString() != value);
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }
        /// <summary>
        ///  添加/修改键值对内容
        /// </summary>
        /// <param name="path">注册表路径</param>
        /// <param name="subKey">注册表子健</param>
        /// <param name="registryKey">注册表键</param>
        /// <param name="value">注册表值</param>
        /// <param name="operateObject">查找注册表的根目录</param>
        public static void SaveSubKey(string path, string subKey, string registryKey, object value,
            OperateObjectType operateObject = OperateObjectType.LocalMachine)
        {
            RegistryKey key = null;
            try
            {
                if (operateObject.ToString().Equals("LocalMachine"))
                {
                    key = Registry.LocalMachine.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Users"))
                {
                    key = Registry.Users.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentUser"))
                {
                    key = Registry.CurrentUser.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Root"))
                {
                    key = Registry.ClassesRoot.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentConfig"))
                {
                    key = Registry.CurrentConfig.OpenSubKey(path, true);
                }
                if (key == null) return;
                var regKey = key.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (regKey != null)
                    regKey
                        .SetValue(registryKey, value, RegistryValueKind.DWord);
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }
        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="path">注册表路径</param>
        /// <param name="subKey">注册表子健</param>
        /// <param name="registryKey">注册表键</param>
        /// <param name="operateObject">查找注册表的根目录</param>
        public static void DeleteSubKey(string path, string subKey, string registryKey,
            OperateObjectType operateObject = OperateObjectType.LocalMachine)
        {
            RegistryKey key = null;
            try
            {
                if (operateObject.ToString().Equals("LocalMachine"))
                {
                    key = Registry.LocalMachine.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Users"))
                {
                    key = Registry.Users.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentUser"))
                {
                    key = Registry.CurrentUser.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("Root"))
                {
                    key = Registry.ClassesRoot.OpenSubKey(path, true);
                }
                else if (operateObject.ToString().Equals("CurrentConfig"))
                {
                    key = Registry.CurrentConfig.OpenSubKey(path, true);
                }
                if (key == null) return;
                var subItem = key.OpenSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (subItem != null)
                {
                    subItem.DeleteValue(registryKey, false);
                }
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }
        /// <summary>
        /// 获取路径下的列表
        /// </summary>
        /// <param name="regPath">注册表路径</param>
        /// <param name="param">注册表键列表</param>
        /// <param name="operateObject">注册表根位置</param>
        /// <returns></returns>
        public static List<string> GetSubKeyListByCondition(string regPath, List<string> param,
            OperateObjectType operateObject =OperateObjectType.LocalMachine)
        {
            RegistryKey key = null;
            var list = new List<string>();
            try
            {
                if (operateObject.ToString().Equals("LocalMachine"))
                {
                    key = Registry.LocalMachine.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("Users"))
                {
                    key = Registry.Users.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("CurrentUser"))
                {
                    key = Registry.CurrentUser.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("Root"))
                {
                    key = Registry.ClassesRoot.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("CurrentConfig"))
                {
                    key = Registry.CurrentConfig.OpenSubKey(regPath, true);
                }
                if (key == null) return null;
                foreach (var subKeyName in key.GetSubKeyNames())
                {
                    var subKey = key.OpenSubKey(subKeyName);
                    if (subKey == null) continue;
                    var stringBuilder = new StringBuilder();
                    foreach (var item in param)
                    {
                        stringBuilder.Append(subKey.GetValue(item) != null ? subKey.GetValue(item).ToString() : "");
                        stringBuilder.Append(";");

                    }
                    if(!string.IsNullOrEmpty(stringBuilder.ToString().TrimEnd(';')))
                    {
                        list.Add(stringBuilder.ToString().TrimEnd(';'));
                    }
                }
                return list;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }

        /// <summary>
        /// 获取路径下的列表
        /// </summary>
        /// <param name="regPath">注册表路径</param>
        /// <param name="param">注册表键列表</param>
        /// <param name="operateObject">注册表根位置</param>
        /// <returns></returns>
        public static string GetValueListByCondition(string regPath, string param,
            OperateObjectType operateObject = OperateObjectType.LocalMachine)
        {
            RegistryKey key = null;
            try
            {
                if (operateObject.ToString().Equals("LocalMachine"))
                {
                    key = Registry.LocalMachine.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("Users"))
                {
                    key = Registry.Users.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("CurrentUser"))
                {
                    key = Registry.CurrentUser.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("Root"))
                {
                    key = Registry.ClassesRoot.OpenSubKey(regPath, true);
                }
                else if (operateObject.ToString().Equals("CurrentConfig"))
                {
                    key = Registry.CurrentConfig.OpenSubKey(regPath, true);
                }
                if (key == null) return null;
                var value = key.GetValue(param);
                if (value == null) return "";
                return value.ToString();
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
        }

    }
}


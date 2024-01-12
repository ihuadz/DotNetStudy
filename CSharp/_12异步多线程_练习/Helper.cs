using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12异步多线程_练习
{
    internal class Helper
    {
        /// <summary>
        /// 获取任务信息
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetPerson()
        {
            string configStr = File.ReadAllText("StoryCharacter.json");
            return JsonConvert.DeserializeObject<List<Person>>(configStr) ?? new List<Person>();
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WikiLibsDiscordBot
{
    public class Message
    {
        public class Commit
        {
            public string Message { get; set; }
            public string Link { get; set; }
        }

        public string Repo { get; set; }
        public string Branch { get; set; }
        public string UserName { get; set; }
        public string RepoLink { get; set; }
        public List<Commit> Commits { get; set; }
        public string HookName { get; set; }
    }

    public static class AzureParser
    {
        public static Message ParseAzure(string data)
        {
            JObject obj = JObject.Parse(data);
            var resource = obj["resource"];
            var repo = resource["repository"];
            var pushBy = resource["pushedBy"];
            var refs = resource["refUpdates"];
            var refSingle = refs.Value<JArray>().FirstOrDefault();
            var str = refSingle == null ? "Unknown" : refSingle["name"].Value<string>();
            var msg = new Message()
            {
                Repo = repo["name"].Value<string>(),
                Branch = str.Substring(str.LastIndexOf('/') + 1),
                UserName = pushBy["displayName"].Value<string>(),
                RepoLink = repo["remoteUrl"].Value<string>(),
                Commits = new List<Message.Commit>()
            };

            foreach (var commit in resource["commits"].Value<JArray>())
            {
                msg.Commits.Add(new Message.Commit()
                {
                    Message = commit["comment"].Value<string>(),
                    Link = commit["url"].Value<string>()
                });
            }
            return (msg);
        }
    }
}

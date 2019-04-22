using System;

namespace WikiLibsDiscordBot.Test
{
    public class AzureParserTests
    {
        public void Basic()
        {
            var str = "{\"subscriptionId\":\"00000000-0000-0000-0000-000000000000\",\"notificationId\":14,\"id\":\"03c164c2-8912-4d5e-8009-3707d5f83734\",\"eventType\":\"git.push\",\"publisherId\":\"tfs\",\"message\":null,\"detailedMessage\":null,\"resource\":{\"commits\":[{\"commitId\":\"33b55f7cb7e7e245323987634f960cf4a6e6bc74\",\"author\":{\"name\":\"Jamal Hartnett\",\"email\":\"fabrikamfiber4@hotmail.com\",\"date\":\"2015-02-25T19:01:00Z\"},\"committer\":{\"name\":\"Jamal Hartnett\",\"email\":\"fabrikamfiber4@hotmail.com\",\"date\":\"2015-02-25T19:01:00Z\"},\"comment\":\"Fixed bug in web.config file\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_git/Fabrikam-Fiber-Git/commit/33b55f7cb7e7e245323987634f960cf4a6e6bc74\"}],\"refUpdates\":[{\"name\":\"refs/heads/master\",\"oldObjectId\":\"aad331d8d3b131fa9ae03cf5e53965b51942618a\",\"newObjectId\":\"33b55f7cb7e7e245323987634f960cf4a6e6bc74\"}],\"repository\":{\"id\":\"278d5cd2-584d-4b63-824a-2ba458937249\",\"name\":\"Fabrikam-Fiber-Git\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249\",\"project\":{\"id\":\"6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c\",\"name\":\"Fabrikam-Fiber-Git\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c\",\"state\":\"wellFormed\",\"visibility\":\"unchanged\",\"lastUpdateTime\":\"0001-01-01T00:00:00\"},\"defaultBranch\":\"refs/heads/master\",\"remoteUrl\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_git/Fabrikam-Fiber-Git\"},\"pushedBy\":{\"displayName\":\"Jamal Hartnett\",\"id\":\"00067FFED5C7AF52@Live.com\",\"uniqueName\":\"fabrikamfiber4@hotmail.com\"},\"pushId\":14,\"date\":\"2014-05-02T19:17:13.3309587Z\",\"url\":\"https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pushes/14\"},\"resourceVersion\":\"1.0\",\"resourceContainers\":{\"collection\":{\"id\":\"c12d0eb8-e382-443b-9f9c-c52cba5014c2\"},\"account\":{\"id\":\"f844ec47-a9db-4511-8281-8b63f4eaf94e\"},\"project\":{\"id\":\"be9b3917-87e6-42a4-a549-2bc06a7a878f\"}},\"createdDate\":\"2019-04-22T07:55:48.3969234Z\"}";

        }
    }
}

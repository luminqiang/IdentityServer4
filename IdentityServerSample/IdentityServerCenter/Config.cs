using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //客户端证书模式

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api"}
                },
                new Client()
                {
                    ClientId = "pwdClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //资源拥有者密码模式

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //可以设置为不验证Client的secert
                    //RequireClientSecret = false, 
                    AllowedScopes = { "api" }
                }
            };
        }
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "luminqiang",
                    Password = "123456"
                }
            };
        }
    }
}
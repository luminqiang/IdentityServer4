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
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //�ͻ���֤��ģʽ

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"api"}
                },
                new Client()
                {
                    ClientId = "pwdClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //��Դӵ��������ģʽ

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //��������Ϊ����֤Client��secert
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
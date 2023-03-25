// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission","catalog_readpermission","catalog_writepermission"}},
                new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermission,api_full_permission,photo_stock_readpermission,photo_stock_writepermission"}},
                new ApiResource("resource_basket"){Scopes={"basket_fullpermission,api_full_permission,basket_readpermission,basket_writepermission"}},
                new ApiResource("resource_discount"){Scopes={"discount_fullpermission,api_full_permission,discount_readpermission,discount_writepermission"}},
                new ApiResource("resource_order"){Scopes={"order_fullpermission,api_full_permission,order_writepermission,order_readpermission"}},
                new ApiResource("resource_payment"){Scopes={"payment_fullpermission,api_full_permission,payment_writepermission,payment_readpermission"}},
                new ApiResource("resource_gateway"){Scopes={"gateway_fullpermission,api_full_permission"}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName),

            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                     
                       new IdentityResource(){Name="roles",DisplayName="Roles",Description="Kullanıcı Rolleri",UserClaims=new[]{ "role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
             new ApiScope("catalog_fullpermission","Catalog API için full erişim"),
             new ApiScope("catalog_writepermission","Catalog API için full erişim"),
             new ApiScope("catalog_readpermission","Catalog API için full erişim"),
             new ApiScope("api_full_permission","API için full erişim"),
             new ApiScope("photo_stock_fullpermission","Photo Stock API için full erişim"),
             new ApiScope("basket_fullpermission","Basket API için full erişim"),
             new ApiScope("discount_fullpermission","Discount API için full erişim"),
             new ApiScope("order_fullpermission","Order API için full erişim"),
             new ApiScope("payment_fullpermission","Fake Payment API için full erişim"),
             new ApiScope("gateway_fullpermission","Gateway Payment API için full erişim"),
             new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName="Asp.Net.Core.Angular",
                    ClientId ="AngularClient",
                    ClientSecrets={new("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={ "catalog_readpermission", "photo_stock_readpermission", "gateway_fullpermission", "api_full_permission",  IdentityServerConstants.LocalApi.ScopeName }
                },
                   new Client
                {
                    ClientName="Asp.Net.Core.Angular",
                    ClientId ="AngularClientForUser",
                    AllowOfflineAccess=true,
                    ClientSecrets={new("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "basket_fullpermission", "discount_fullpermission", "order_fullpermission", "gateway_fullpermission", "payment_fullpermission", "catalog_fullpermission", "photo_stock_fullpermission", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess,"roles",IdentityServerConstants.LocalApi.ScopeName },
                    AccessTokenLifetime=60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds ,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
               
            };
    }
}
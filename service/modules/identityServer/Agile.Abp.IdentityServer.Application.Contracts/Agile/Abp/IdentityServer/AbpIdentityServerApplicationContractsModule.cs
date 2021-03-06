﻿using Volo.Abp.Application;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Agile.Abp.IdentityServer
{
    [DependsOn(new[] { typeof(AbpDddApplicationModule) })]
    [DependsOn(new[] { typeof(AbpIdentityServerDomainSharedModule) })]
    public class AbpIdentityServerApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityServerApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpIdentityServerResource>()
                    .AddVirtualJson("/Agile/Abp/IdentityServer/Localization/Resources");
            });
        }
    }
}

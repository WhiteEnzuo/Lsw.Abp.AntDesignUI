﻿using System.Threading.Tasks;
using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.Toolbars;
using Lsw.Abp.AspnetCore.Components.WebAssembly.AntDesignTheme.Themes.AntDesignTheme;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Lsw.Abp.AspnetCore.Components.WebAssembly.AntDesignTheme;

public class AntDesignThemeToolbarContributor: IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));

            //TODO: Can we find a different way to understand if authentication was configured or not?
            var authenticationStateProvider = context.ServiceProvider
                .GetService<AuthenticationStateProvider>();

            if (authenticationStateProvider != null)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }
        }

        return Task.CompletedTask;
    }
}

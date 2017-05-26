/* http://www.zkea.net/ Copyright 2016 ZKEASOFT http://www.zkea.net/licenses */
using Easy.Mvc.Resource;
using Easy.Mvc.Route;
using System;
using System.Collections.Generic;
using ZKEACMS.Common.Models;
using Microsoft.Extensions.DependencyInjection;
using ZKEACMS.Article.Service;

namespace ZKEACMS.Article
{
    public class ArticlePlug : PluginBase
    {
        public override IEnumerable<RouteDescriptor> RegistRoute()
        {
            return null;
        }

        public override IEnumerable<AdminMenu> AdminMenu()
        {
            yield return new AdminMenu
            {
                Title = "文章管理",
                Icon = "glyphicon-font",
                Order = 10,
                Children = new List<AdminMenu>
                {
                    new AdminMenu
                    {
                        Title = "文章列表",
                        Url = "~/admin/Article",
                        Icon = "glyphicon-align-justify",
                        PermissionKey = PermissionKeys.ViewArticle
                    },
                    new AdminMenu
                    {
                        Title = "文章类别",
                        Url = "~/admin/ArticleType",
                        Icon = "glyphicon-th-list",
                        PermissionKey = PermissionKeys.ViewArticleType
                    }
                }
            };
        }

        protected override void InitScript(Func<string, ResourceHelper> script)
        {

        }

        protected override void InitStyle(Func<string, ResourceHelper> style)
        {
            style("Article").Include("~/Plugins/ZKEACMS.Article/Content/Article.css");
        }

        public override IEnumerable<PermissionDescriptor> RegistPermission()
        {
            yield return new PermissionDescriptor(PermissionKeys.ViewArticle, "文章", "查看文章", "");
            yield return new PermissionDescriptor(PermissionKeys.ManageArticle, "文章", "管理文章", "");
            yield return new PermissionDescriptor(PermissionKeys.PublishArticle, "文章", "发布文章", "");
            yield return new PermissionDescriptor(PermissionKeys.ViewArticleType, "文章", "查看文章类别", "");
            yield return new PermissionDescriptor(PermissionKeys.ManageArticleType, "文章", "管理文章类别", "");
        }

        public override IEnumerable<Type> WidgetServiceTypes()
        {
            yield return typeof(ArticleDetailWidgetService);
            yield return typeof(ArticleListWidgetService);
            yield return typeof(ArticleSummaryWidgetService);
            yield return typeof(ArticleTopWidgetService);
            yield return typeof(ArticleTypeWidgetService);
        }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IArticleService, ArticleService>();
            serviceCollection.AddTransient<IArticleTypeService, ArticleTypeService>();
        }
    }
}
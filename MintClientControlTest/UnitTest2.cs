using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using MintClientControl.ViewModels;
using MintClientControl.Views;
using System;
using Xunit;

namespace MintClientControlTest
{
    public class UnitTest2
    {
        [Fact]
        public void TestIsAuth()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");
            ctx.Services.AddSingleton<IFunctionViewModel>(new FunctionViewModel());
            // Act
            var cut = ctx.RenderComponent<FunctionView>();
            var smallElm = cut.Find("h1");

            // Assert
            smallElm.MarkupMatches(@"<h1 >Hello, TEST USER</h1>");  
        }
        [Fact]
        public void TestIsNotAuth()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            ctx.Services.AddSingleton<IFunctionViewModel>(new FunctionViewModel());
            // Act
            var cut = ctx.RenderComponent<FunctionView>();
            var smallElm = cut.Find("p");

            // Assert
            smallElm.MarkupMatches(@"<p>Oops. You're not logged in yet. Please log in to see your personal function buttons.</p>");  
        }
        [Fact]
        public void TestAddFunction()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");
            ctx.Services.AddSingleton<IFunctionViewModel>(new FunctionViewModel());
            // Act
            var cut = ctx.RenderComponent<FunctionView>();

            // Assert
        }
    }
}

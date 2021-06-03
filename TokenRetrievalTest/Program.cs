using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TokenRetrievalTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configName = "talent-dev-core-ac";

            var sw = new Stopwatch();

            sw.Restart();
            try
            {
                var token1 = await new AzureServiceTokenProvider().GetAccessTokenAsync("https://graph.microsoft.com");
                Console.WriteLine($"{sw.Elapsed}: Graph, ASTP: {token1.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: Graph, ASTP");
            }

            sw.Restart();
            try
            {
                var context2 = new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" });
                var token2 = await new VisualStudioCodeCredential().GetTokenAsync(context2, default);
                Console.WriteLine($"{sw.Elapsed}: Graph, Identity, VSCode: {token2.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: Graph, Identity, VSCode");
            }

            sw.Restart();
            try
            {
                var context3 = new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" });
                var token3 = await new AzureCliCredential().GetTokenAsync(context3);
                Console.WriteLine($"{sw.Elapsed}: Graph, Identity, Azure CLI: {token3.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: Graph, Identity, Azure CLI");
            }

            sw.Restart();
            try
            {
                var context4 = new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" });
                var token4 = await new VisualStudioCredential().GetTokenAsync(context4, default);
                Console.WriteLine($"{sw.Elapsed}: Graph, Identity, VS: {token4.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: Graph");
            }

            sw.Restart();
            try
            {
                var context4 = new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" });
                var token4 = await new DefaultAzureCredential().GetTokenAsync(context4, default);
                Console.WriteLine($"{sw.Elapsed}: Graph, Identity, Default: {token4.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: Graph, Identity, Default");
            }

            sw.Restart();
            try
            {
                var token5 = await new AzureServiceTokenProvider().GetAccessTokenAsync($"https://{configName}.azconfig.io");
                Console.WriteLine($"{sw.Elapsed}: AzConfig, ASTP: {token5.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: AzConfig, ASTP");
            }

            sw.Restart();
            try
            {
                var context6 = new TokenRequestContext(new[] { $"https://{configName}.azconfig.io/.default" });
                var token6 = await new VisualStudioCodeCredential().GetTokenAsync(context6, default);
                Console.WriteLine($"{sw.Elapsed}: AzConfig, Identity, VSCode: {token6.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: AzConfig, Identity, VSCode");
            }

            sw.Restart();
            try
            {
                var context7 = new TokenRequestContext(new[] { $"https://{configName}.azconfig.io/.default" });
                var token7 = await new AzureCliCredential().GetTokenAsync(context7);
                Console.WriteLine($"{sw.Elapsed}: AzConfig, Identity, Azure CLI: {token7.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: AzConfig, Identity, Azure CLI");
            }

            sw.Restart();
            try
            {
                var context8 = new TokenRequestContext(new[] { $"https://{configName}.azconfig.io/.default" });
                var token8 = await new VisualStudioCredential().GetTokenAsync(context8, default);
                Console.WriteLine($"{sw.Elapsed}: AzConfig, Identity, VS: {token8.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: AzConfig, Identity, VS");
            }

            sw.Restart();
            try
            {
                var context = new TokenRequestContext(new[] { $"https://{configName}.azconfig.io/.default" });
                var token = await new DefaultAzureCredential().GetTokenAsync(context, default);
                Console.WriteLine($"{sw.Elapsed}: AzConfig, Identity, Default: {token.Token.Substring(0, 8)}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FAILED: AzConfig, Identity, Default");
            }
        }
    }
}

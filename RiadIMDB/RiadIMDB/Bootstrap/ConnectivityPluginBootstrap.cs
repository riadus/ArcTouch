using MvvmCross.Platform.Plugins;

namespace RiadIMDB.iOS.Bootstrap
{
    public class ConnectivityPluginBootstrap
        : MvxLoaderPluginBootstrapAction<Cheesebaron.MvxPlugins.Connectivity.PluginLoader, 
			Cheesebaron.MvxPlugins.Connectivity.Touch.Plugin> { }
}
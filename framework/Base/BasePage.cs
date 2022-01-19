using framework.Settings;
using System;

namespace framework.Base
{
    public abstract class BasePage 
    {
        public readonly ParallelConfig _parallelConfig;

        public BasePage(ParallelConfig parellelConfig) 
        {
            _parallelConfig = parellelConfig;
        }
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}

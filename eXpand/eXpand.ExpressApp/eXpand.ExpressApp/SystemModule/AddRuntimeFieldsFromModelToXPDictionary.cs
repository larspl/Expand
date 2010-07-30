using System;
using DevExpress.ExpressApp;
using eXpand.Persistent.Base;
using eXpand.ExpressApp.Core.DictionaryHelpers;

namespace eXpand.ExpressApp.SystemModule
{

    public class AddRuntimeFieldsFromModelToXPDictionary : ViewController, IModelExtender
    {
        public AddRuntimeFieldsFromModelToXPDictionary()
        {
            TargetObjectType = typeof(IXpoModelDifference);
        }


        protected override void OnActivated()
        {
            base.OnActivated();
            View.ObjectSpace.Committed += ObjectSpaceOnCommitted;
        }

        protected override void OnDeactivating()
        {
            base.OnDeactivating();
            View.ObjectSpace.Committed -= ObjectSpaceOnCommitted;
        }

        private void ObjectSpaceOnCommitted(object sender, EventArgs args)
        {
            DictionaryHelper.AddFields(Application.Model, XafTypesInfo.XpoTypeInfoSource.XPDictionary);
        }
    }
}
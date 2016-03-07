using Csla.Core;
using Csla.Serialization.Mobile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DH.Lending.Borrower.Business.Repository
{
    public interface IDHBusinessListBase<C>
        : IEditableCollection, IBusinessObject, ISupportUndo, ITrackStatus, INotifyBusy, INotifyUnhandledAsyncException, IUndoableObject, ICloneable, ISavable, IParent, IObservableBindingList, INotifyChildChanged, ISerializationNotification, IMobileObject, INotifyCollectionChanged, INotifyPropertyChanged, IEnumerable<C>, IEnumerable
    {
    }
}

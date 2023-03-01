// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2022 Dassault Systèmes - CPE EMED
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ------------------------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

using ws3dx.client;
using ws3dx.client.impl;
using ws3dx.serialization.attribute;
using ws3dx.shared.data;

namespace ws3dx.data.impl
{
   public class Item2 : IItemPatch, IItemMask, INotifyPropertyChanging, INotifyPropertyChanged
   {
      private const string ID = "id";
      private const string TYPE = "type";
      private const string CREATED = "created";
      private const string MODIFIED = "modified";
      private const string NAME = "name";
      private const string DESCRIPTION = "description";
      private const string TITLE = "title";
      private const string REVISION = "revision";
      private const string STATE = "state";
      private const string ORGANIZATION = "organization";
      private const string OWNER = "owner";
      private const string COLLABSPACE = "collabspace";
      private const string CESTAMP = "cestamp";

      private string m_title = null;
      private string m_description = null;

      #region - Track property changes and notification variables

      public event PropertyChangedEventHandler PropertyChanged;
      public event PropertyChangingEventHandler PropertyChanging;

      Dictionary<string, IPropertyUpdate> m_propertyUpdates = new Dictionary<string, IPropertyUpdate>();
      Dictionary<string, bool> m_propertyInitialization = new Dictionary<string, bool>();

      private bool m_trackChanges = false;
      private bool m_propertyNotification = false;

      #endregion

      public Item2(bool _trackChanges = false, bool _propertyNotification = false)
      {
         SetTrackChanges(_trackChanges);
         SetPropertyNotification(_propertyNotification);
      }

      [JsonPropertyName(ID)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Id { get; set; }

      [JsonPropertyName(TYPE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Type { get; set; }

      [JsonPropertyName(CREATED)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Created { get; set; }

      [JsonPropertyName(MODIFIED)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Modified { get; set; }

      [JsonPropertyName(NAME)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Name { get; set; }

      [JsonPropertyName(DESCRIPTION)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Description { get => m_description; set => SetProperty(ref m_description, value); }

      [JsonPropertyName(TITLE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Title { get => m_title; set => SetProperty(ref m_title, value); }

      [JsonPropertyName(REVISION)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Revision { get; set; }

      [JsonPropertyName(STATE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string State { get; set; }

      [JsonPropertyName(OWNER)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Owner { get; set; }

      [JsonPropertyName(ORGANIZATION)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Organization { get; set; }

      [JsonPropertyName(COLLABSPACE)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Collabspace { get; set; }

      [ContextSerialization(CESTAMP, SerializationContext.PATCH)]
      [JsonPropertyName(CESTAMP)]
      [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
      public string Cestamp { get; set; }

      #region PropertyNotification

      public void SetPropertyNotification(bool _propertyNotification)
      {
         m_propertyNotification = _propertyNotification;
      }

      public bool GetPropertyNotification()
      {
         return m_propertyNotification;
      }

      private void TrackChanges_PropertyChanging([CallerMemberName] string propertyName = "")
      {
         m_propertyUpdates[propertyName] = new PropertyUpdate(propertyName, GetPropertyValue(propertyName));
      }

      private void TrackChanges_PropertyChanged([CallerMemberName] string propertyName = "")
      {
         ((PropertyUpdate)m_propertyUpdates[propertyName]).CurrentValue = GetPropertyValue(propertyName);
      }

      protected void NotifyPropertyChanging([CallerMemberName] string propertyName = "")
      {
         if (!GetPropertyNotification()) return;

         if (PropertyChanging != null)
         {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
         }
      }

      protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      {
         if (!GetPropertyNotification()) return;

         if (PropertyChanged != null)
         {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }

      protected object GetPropertyValue(string _propertyName)
      {
         PropertyInfo property = GetProperty(_propertyName);

         if (null == property)
            throw new KeyNotFoundException(_propertyName);

         return property.GetValue(this);
      }

      protected PropertyInfo GetProperty(string _propertyName)
      {
         return GetType().GetProperty(_propertyName);
      }

      protected void SetProperty<T>(ref T _var, T _value, [CallerMemberName] string _property = "")
      {
         NotifyPropertyChanging(_property);

         // TODO: SIMPLIFY THIS CODE
         // first time a property is set we assume it is initializing and it should not be recorded as an "update"
         // another option could be to modify the serialization to call an InitializeProperty method
         if (!m_propertyInitialization.ContainsKey(_property))
         {
            m_propertyInitialization.Add(_property, true);
         }
         else
         {
            m_propertyInitialization[_property] = false;
         };

         bool isInitializingProperty = m_propertyInitialization[_property];

         if (!isInitializingProperty)
         {
            TrackChanges_PropertyChanging(_property);
         }

         _var = _value;

         if (!isInitializingProperty)
         {
            TrackChanges_PropertyChanged(_property);
         }

         NotifyPropertyChanged(_property);
      }
      #endregion

      #region - Track property changes and notification

      public void SetTrackChanges(bool _trackChanges)
      {
         m_trackChanges = _trackChanges;
      }

      public bool GetTrackChanges() => m_trackChanges;

      public bool GetHasChanges() => (m_propertyUpdates.Count > 0);

      public IEnumerator<IPropertyUpdate> GetChanges()
      {
         return m_propertyUpdates.Values.GetEnumerator();
      }

      #endregion
   }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace libyoutube_dl
{
    /// <summary>Represents the list of available formats of the video. Used by the VideoItem class to store the format list.</summary>
    public class VideoFormatList : IList<FormatProperty>
    {
        private List<FormatProperty> Items;

        /// <summary>Gets or sets the element at the specified index.</summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The element at the specified index.</returns>
        public FormatProperty this[int index] { get => Items[index]; set => Items[index] = value; }

        /// <summary>Initializes a new instance of the the list.</summary>
        public VideoFormatList()
        {
            Items = new List<FormatProperty>();
        }

        /// <summary>Gets or sets the selected item's index.</summary>
        public int SelectedIndex
        {
            get
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].IsSelected) return i;
                }
                return -1;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    Items[i].IsSelected = false;
                }
                Items[value].IsSelected = true;
                OnSelectedIndexChanged(SelectedIndexChangedArgs);
            }
        }

        /// <summary>Gets the number of elements contained in the collection.</summary>
        public int Count => ((ICollection<FormatProperty>)Items).Count;

        /// <summary>Gets the value indicating whether the collection is read-only.</summary>
        public bool IsReadOnly => ((ICollection<FormatProperty>)Items).IsReadOnly;

        // SelectedItemChanged event

        private EventArgs SelectedIndexChangedArgs = new EventArgs();
        
        /// <summary>Occurs when the SelectedIndex of VideoFormatList changed.</summary>
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;
        
        /// <summary>Represents the method that handles the VideoFormatList.SelectedIndexChanged event.</summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);
        
        /// <summary>Raises the SelectedIndexChanged event.</summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            SelectedIndexChanged?.Invoke(this, e);
        }

        /// <summary>Determines the index of a specific item in the collection.</summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>The index of item if found in the collection, otherwise -1.</returns>
        public int IndexOf(FormatProperty item)
        {
            return ((IList<FormatProperty>)Items).IndexOf(item);
        }

        /// <summary>Insert an item to the collection at the specified index.</summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the collection.</param>
        public void Insert(int index, FormatProperty item)
        {
            ((IList<FormatProperty>)Items).Insert(index, item);
        }

        /// <summary>Removes the collection item at the specified index.</summary>
        /// <param name="index">The zero-based index to remove.</param>
        public void RemoveAt(int index)
        {
            ((IList<FormatProperty>)Items).RemoveAt(index);
        }

        /// <summary>Adds a new VideoItem to the collection.</summary>
        /// <param name="item">Object to add to the collection.</param>
        public void Add(FormatProperty item)
        {
            ((ICollection<FormatProperty>)Items).Add(item);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            ((ICollection<FormatProperty>)Items).Clear();
        }

        /// <summary>Determines whether the collection contains a specific value.</summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>true if item is found in the collection.</returns>
        public bool Contains(FormatProperty item)
        {
            return ((ICollection<FormatProperty>)Items).Contains(item);
        }

        /// <summary>Copyes the elements of the collection starting starting at a particular Array index.</summary>
        /// <param name="array">The one-dimensional array that is the destinations of the elements copied from the collection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(FormatProperty[] array, int arrayIndex)
        {
            ((ICollection<FormatProperty>)Items).CopyTo(array, arrayIndex);
        }

        /// <summary>Removes the first occurrence of a specific object from the collection.</summary>
        /// <param name="item">The object to remove from the collection.</param>
        /// <returns>True the item was successfully removed from the collection otherwise, false. This method also returns false, if item is not found in the original collection.</returns>
        public bool Remove(FormatProperty item)
        {
            return ((ICollection<FormatProperty>)Items).Remove(item);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<FormatProperty> GetEnumerator()
        {
            return ((IEnumerable<FormatProperty>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }
    }

    /// <summary>Represents the single properties of format.</summary>
    public class FormatProperty
    {
        /// <summary>Stores the Format Code of the format.</summary>
        public string FormatCode { get; set; }

        /// <summary>Stores the Extension of the format.</summary>
        public string Extension { get; set; }

        /// <summary>Stores the Resolution of the format.</summary>
        public string Resolution { get; set; }

        /// <summary>Stores additional information of the format.</summary>
        public string Note { get; set; }

        /// <summary>Determines whether the item is selected.</summary>
        public bool IsSelected = false;
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace libyoutube_dl
{
    /// <summary>
    /// Represents the collection of VideoItems. Has the features that can be used to manage list of VideoItems.
    /// </summary>
    public class VideoItemCollection : IList<VideoItem>
    {
        private int infoThreads = 4;
        private int downloadThreads = 4;
        private int formatThreads = 4;
        private int threadLimit = 20;
        private Settings VSettings;
        private BackgroundWorker InfoScheduler, FormatScheduler, VideoScheduler;
        private bool InfoSchedulerSuspended = false, FormatSchedulerSuspended = false, VideoSchedulerSuspended = false;

        private List<VideoItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The element at the specified index.</returns>
        public VideoItem this[int index] { get => ((IList<VideoItem>)Items)[index]; set => ((IList<VideoItem>)Items)[index] = value; }

        /// <summary>
        /// Gets or sets the number of threads are allowed to be run at once, when querying the videos' information.
        /// </summary>
        public int MaxVideoInfoThread
        {
            get { return infoThreads; }
            set
            {
                infoThreads = value;
                if (value > threadLimit) infoThreads = threadLimit;
                if (value < 1) infoThreads = 1;
            }
        }

        /// <summary>
        /// Gets or sets the number of threads are allowed to be run at once, when querying the video's format list.
        /// </summary>
        public int MaxVideoDownloadThread
        {
            get { return downloadThreads; }
            set
            {
                downloadThreads = value;
                if (value > threadLimit) downloadThreads = threadLimit;
                if (value < 1) downloadThreads = 1;
            }
        }

        /// <summary>
        /// Gets or sets the number of threads are allowed to be run at once, when downloading the videos.
        /// </summary>
        public int MaxVideoFormatThread
        {
            get { return formatThreads; }
            set
            {
                formatThreads = value;
                if (value > threadLimit) formatThreads = threadLimit;
                if (value < 1) formatThreads = 1;
            }
        }

        /// <summary>
        /// Checks whether the VideoUrl of items has already exists within the collection.
        /// </summary>
        /// <param name="Url">Url to check.</param>
        /// <returns>True if there is an item that have this url.</returns>
        public bool HasUrl(string Url)
        {
            int s = 0;
            foreach (VideoItem item in this)
            {
                if (item.VideoUrl == Url) s++;
            }
            if (s > 0) return true;
            else return false;
        }

        /// <summary>
        /// Gets the number of finished state objects.
        /// </summary>
        public int FinishedCount
        {
            get
            {
                int c = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (Items[i].VideoQueried) c++;
                }
                return c;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Collection.
        /// </summary>
        /// <param name="settings">An existing instance of Settings class must be declared within your application. This contains many setting option for the downloader.</param>
        public VideoItemCollection(ref Settings settings)
        {
            Items = new List<VideoItem>();
            VSettings = settings; // References to the original settings object in the main program. Not a new instance.
            if (!PatternFile.Initialized) PatternFile.LoadDefinitions(AppContext.BaseDirectory + "Definitions.xml");
            ItemRemovedArgs = new ItemRemovedEventArgs();
            InfoScheduler = new BackgroundWorker() { WorkerSupportsCancellation = true };
            InfoScheduler.DoWork += InfoScheduler_DoWork;
            FormatScheduler = new BackgroundWorker() { WorkerSupportsCancellation = true };
            FormatScheduler.DoWork += FormatScheduler_DoWork;
            VideoScheduler = new BackgroundWorker() { WorkerSupportsCancellation = true };
            VideoScheduler.DoWork += VideoScheduler_DoWork;
        }

        /// <summary>
        /// Returns the number of information querying process that are currently running.
        /// </summary>
        /// <returns>The number of processes that are running.</returns>
        public int GetCurrentInfoThreads()
        {
            int s = 0;
            foreach (VideoItem item in Items)
            {
                if (item.InfoQuerying) s++;
            }
            return s;
        }

        /// <summary>
        /// Returns the number of downloading process that are currently running.
        /// </summary>
        /// <returns>The number of processes that are running.</returns>
        public int GetCurrentVideoThreads()
        {
            int s = 0;
            foreach (VideoItem item in Items)
            {
                if (item.VideoQuerying) s++;
            }
            return s;
        }

        /// <summary>
        /// Returns the number of format querying process that are currently running.
        /// </summary>
        /// <returns>The number of processes that are running.</returns>
        public int GetCurrentFormatThreads()
        {
            int s = 0;
            foreach (VideoItem item in Items)
            {
                if (item.FormatQuerying) s++;
            }
            return s;
        }

        /// <summary>
        /// Starts the information query of a single item.
        /// </summary>
        /// <param name="index">The index of the item within the collection.</param>
        /// <returns>True if the index less than the size of collection and the current process thread is less than allowed threads and the external process is successfully started.</returns>
        public bool StartInfoQuery(int index)
        {
            MaxVideoInfoThread = VSettings.Threads_VideoInfo;
            if (index < Items.Count)
                if (GetCurrentInfoThreads() < MaxVideoInfoThread)
                {
                    if (Items[index].StartInfoQuery()) return true;
                    else
                    {
                        //SuspendInfoQueryScheduler();
                        InfoScheduler.CancelAsync();
                        return false;
                    }
                }
                else return false;
            else return false;
        }

        /// <summary>
        /// Starts the download of a single video.
        /// </summary>
        /// <param name="index">The index of the item within the collection.</param>
        /// <returns>True if the index less than the size of collection and the current process thread is less than allowed threads and the external process is successfully started.</returns>
        public bool StartVideoQuery(int index)
        {
            MaxVideoDownloadThread = VSettings.Threads_VideoDownload;
            if (GetCurrentVideoThreads() < MaxVideoDownloadThread)
            {
                if (Items[index].StartVideoQuery()) return true;
                else
                {
                    //SuspendVideoQueryScheduler();
                    VideoScheduler.CancelAsync();
                    return false;
                }
            }
            else return false;
        }

        /// <summary>
        /// Starts the formatlist query of a single item.
        /// </summary>
        /// <param name="index">The index of the item within the collection.</param>
        /// <returns>True if the index less than the size of collection and the current process thread is less than allowed threads and the external process is successfully started.</returns>
        public bool StartFormatQuery(int index)
        {
            MaxVideoFormatThread = VSettings.Threads_VideoFormat;
            if (GetCurrentFormatThreads() < MaxVideoFormatThread)
            {
                if (Items[index].StartFormatQuery()) return true;
                else
                {
                    FormatScheduler.CancelAsync();
                    return false;
                }
            }
            else return false;
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count => ((IList<VideoItem>)Items).Count;

        /// <summary>
        /// Gets the value indicating whether the collection is read-only.
        /// </summary>
        public bool IsReadOnly => ((IList<VideoItem>)Items).IsReadOnly;

        /// <summary>
        /// Adds a new VideoItem to the collection.
        /// </summary>
        /// <param name="item">Object to add to the collection.</param>
        public void Add(VideoItem item)
        {
            ((IList<VideoItem>)Items).Add(item);
            ((IList<VideoItem>)Items)[Count - 1].ListIndex = Count - 1;
        }

        /// <summary>
        /// Adds a new VideoItem to the collection.
        /// </summary>
        /// <param name="url">Url of the video.</param>
        public void Add(string url)
        {
            ((IList<VideoItem>)Items).Add(new VideoItem(url, ref VSettings));
            ((IList<VideoItem>)Items)[Count - 1].ListIndex = Count - 1;
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            ((IList<VideoItem>)Items).Clear();
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>true if item is found in the collection.</returns>
        public bool Contains(VideoItem item)
        {
            return ((IList<VideoItem>)Items).Contains(item);
        }

        /// <summary>
        /// Copyes the elements of the collection starting starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destinations of the elements copied from the collection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(VideoItem[] array, int arrayIndex)
        {
            ((IList<VideoItem>)Items).CopyTo(array, arrayIndex);
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<VideoItem> GetEnumerator()
        {
            return ((IList<VideoItem>)Items).GetEnumerator();
        }

        /// <summary>
        /// Determines the index of a specific item in the collection.
        /// </summary>
        /// <param name="item">The object to locate in the collection.</param>
        /// <returns>The index of item if found in the collection, otherwise -1.</returns>
        public int IndexOf(VideoItem item)
        {
            return ((IList<VideoItem>)Items).IndexOf(item);
        }

        /// <summary>
        /// Insert an item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the collection.</param>
        public void Insert(int index, VideoItem item)
        {
            ((IList<VideoItem>)Items).Insert(index, item);
        }

        private async Task StopAllProcess(int index)
        {
            SuspendInfoQueryScheduler();
            SuspendFormatQueryScheduler();
            SuspendVideoQueryScheduler();
            await Items[index].StopInfoQueryAsync();
            await Items[index].StopFormatQueryAsync();
            await Items[index].StopVideoQueryAsync();
            ResumeInfoQueryScheduler();
            ResumeFormatQueryScheduler();
            ResumeVideoQueryScheduler();
        }

        /// <summary>
        /// Removes the first occurrences of the specified object from he collection. Asynchronous. Waits until the processes are closed. Calls ItemRemoved event.
        /// </summary>
        /// <param name="item">The VideoItem instance to be removed.</param>
        public async Task RemoveAsync(VideoItem item)
        {
            await StopAllProcess(item.ListIndex);
            Remove(item);
        }

        /// <summary>
        /// Removes the item at the specified index. Asynchronous. Waits until the processes are closed.
        /// </summary>
        /// <param name="index">The index of the item to be removed.</param>
        public async Task RemoveAtAsync(int index)
        {
            await StopAllProcess(index);
            RemoveAt(index);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The object to remove from the collection.</param>
        /// <returns>True the item was successfully removed from the collection otherwise, false. This method also returns false, if item is not found in the original collection.</returns>
        public bool Remove(VideoItem item)
        {
            // The following items moves up one position in the list.
            for (int i = item.ListIndex + 1; i < Items.Count; i++) { Items[i].ListIndex--; }
            bool r = ((IList<VideoItem>)Items).Remove(item);
            ItemRemovedArgs.ItemIndex = item.ListIndex;
            OnItemRemoved(ItemRemovedArgs);
            return r;
        }

        /// <summary>
        /// Removes the collection item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index to remove.</param>
        public void RemoveAt(int index)
        {
            // The following items moves up one position in the list.
            for (int i = index + 1; i < Items.Count; i++) { Items[i].ListIndex--; }
            ((IList<VideoItem>)Items).RemoveAt(index);
            ItemRemovedArgs.ItemIndex = index;
            OnItemRemoved(ItemRemovedArgs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<VideoItem>)Items).GetEnumerator();
        }

        /// <summary>
        /// Starts the querying of the videos' information for the items that ToQueryInfo is true, using scheduler.
        /// </summary>
        public void StartInfoQueryScheduler()
        {
            if (!InfoScheduler.IsBusy) InfoScheduler.RunWorkerAsync();
        }

        /// <summary>
        /// Starts the querying of the videos' formatlist for the items that ToQueryFormat is true, using scheduler.
        /// </summary>
        // Starts a scheduler that query the selected videos' format lists. If the videos' number are beyond the limit of threads the scheduler is put on hold the videos.
        public void StartFormatQueryScheduler()
        {
            if (!FormatScheduler.IsBusy) FormatScheduler.RunWorkerAsync();
        }

        /// <summary>
        /// Starts the downloading of the videos' which are ToQueryVideo property is true, using scheduler.
        /// </summary>
        public void StartVideoQueryScheduler()
        {
            if (!VideoScheduler.IsBusy) VideoScheduler.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the scheduler that querying the videos' information.
        /// </summary>
        public void StopInfoQueryScheduler()
        {
            if (InfoScheduler.IsBusy) InfoScheduler.CancelAsync();
        }

        /// <summary>
        /// Stops the scheduler that querying the videos' formatlists.
        /// </summary>
        public void StopFormatQueryScheduler()
        {
            if (FormatScheduler.IsBusy) FormatScheduler.CancelAsync();
        }

        /// <summary>
        /// Stops the scheduler that downloading the videos.
        /// </summary>
        public void StopVideoQueryScheduler()
        {
            if (VideoScheduler.IsBusy) VideoScheduler.CancelAsync();
        }

        /// <summary>
        /// Suspends the scheduler that querying the videos' information.
        /// </summary>
        public void SuspendInfoQueryScheduler()
        {
            InfoSchedulerSuspended = true;
        }

        /// <summary>
        /// Suspends the scheduler that querying the videos' format list.
        /// </summary>
        public void SuspendFormatQueryScheduler()
        {
            FormatSchedulerSuspended = true;
        }

        /// <summary>
        /// Suspends the scheduler that downloading the videos.
        /// </summary>
        public void SuspendVideoQueryScheduler()
        {
            VideoSchedulerSuspended = true;
        }

        /// <summary>
        /// Resumes the scheduler that querying the videos' information.
        /// </summary>
        public void ResumeInfoQueryScheduler()
        {
            InfoSchedulerSuspended = false;
        }

        /// <summary>
        /// Resumes the scheduler that querying the videos' format list.
        /// </summary>
        public void ResumeFormatQueryScheduler()
        {
            FormatSchedulerSuspended = false;
        }

        /// <summary>
        /// Resumes the scheduler that downloading the videos.
        /// </summary>
        public void ResumeVideoQueryScheduler()
        {
            VideoSchedulerSuspended = false;
        }

        private void InfoScheduler_DoWork(object sender, DoWorkEventArgs e)
        {
            int PendingCount;
            int c;
            do
            {
                while (InfoSchedulerSuspended) { Thread.Sleep(100); }
                Thread.Sleep(100);
                PendingCount = 0;
                c = Items.Count;
                for (int i = 0; i < c; i++)
                {
                    if (!InfoSchedulerSuspended)
                    {
                        if (Items[i].ToQueryInfo && !Items[i].InfoQueried && !Items[i].InfoQuerying)
                        {
                            if (StartInfoQuery(Items[i].ListIndex))
                            {
                                Items[i].ToQueryInfo = false;
                            }
                        }
                        if (i < Items.Count)
                            if (Items[i].ToQueryInfo && Items[i].InfoQueried)
                                Items[i].ToQueryInfo = false;
                    }
                    
                }
                for (int i = 0; i < c; i++)
                {
                    if (i < Items.Count)
                        if (Items[i].ToQueryInfo)
                            PendingCount++;
                }
            } while ((!InfoScheduler.CancellationPending) && (PendingCount > 0));
        }

        private void FormatScheduler_DoWork(object sender, DoWorkEventArgs e)
        {
            int PendingCount;
            int c;
            do
            {
                while (FormatSchedulerSuspended) { Thread.Sleep(100); }
                Thread.Sleep(100);
                PendingCount = 0;
                c = Items.Count;
                for (int i=0; i <c; i++)
                {
                    if (!FormatSchedulerSuspended)
                    {
                        if (Items[i].ToQueryFormat && !Items[i].FormatQueried && !Items[i].FormatQuerying)
                        {
                            if (StartFormatQuery(Items[i].ListIndex))
                                Items[i].ToQueryFormat = false;
                        }
                        if (i < Items.Count)
                            if (Items[i].ToQueryFormat && Items[i].FormatQueried)
                            Items[i].ToQueryFormat = false;
                    }
                }
                for (int i = 0; i < c; i++)
                {
                    if (i < Items.Count)
                        if (Items[i].ToQueryFormat)
                        PendingCount++;
                }
            } while ((!FormatScheduler.CancellationPending) && (PendingCount > 0));
        }

        private void VideoScheduler_DoWork(object sender, DoWorkEventArgs e)
        {
            int PendingCount;
            int c;
            do
            {
                while (VideoSchedulerSuspended) { Thread.Sleep(100); }
                Thread.Sleep(100);
                PendingCount = 0;
                c = Items.Count;
                for (int i = 0; i < c; i++)
                {
                    if (!VideoSchedulerSuspended)
                    {
                        if (Items[i].ToQueryVideo && !Items[i].VideoQueried && !Items[i].VideoQuerying)
                        {
                            if (StartVideoQuery(Items[i].ListIndex))
                                Items[i].ToQueryVideo = false;
                        }
                        if (i < Items.Count)
                            if (Items[i].ToQueryVideo && Items[i].VideoQueried)
                            Items[i].ToQueryVideo = false;
                    }
                }
                for (int i = 0; i < c; i++)
                {
                    if (i < Items.Count)
                        if (Items[i].ToQueryVideo)
                        PendingCount++;
                }
            } while ((!VideoScheduler.CancellationPending) && (PendingCount > 0));
        }

        // Item deletion complete event

        private ItemRemovedEventArgs ItemRemovedArgs;

        /// <summary>
        /// Occurs when an item was removed from the collection.
        /// </summary>
        public event ItemRemovedEventHandler ItemRemoved;

        /// <summary>
        /// Represents the method that handles the VideoItemCollection.ItemRemoved event.
        /// </summary>
        /// <param name="sender">The calling object.</param>
        /// <param name="e">Contains the event data.</param>
        public delegate void ItemRemovedEventHandler(object sender, ItemRemovedEventArgs e);

        /// <summary>
        /// Raises the ItemRemoved event.
        /// </summary>
        /// <param name="e">Contains the event data.</param>
        protected virtual void OnItemRemoved(ItemRemovedEventArgs e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        /// <summary>
        /// Argument class of the ItemRemovedEventHandler.
        /// </summary>
        public class ItemRemovedEventArgs : EventArgs
        {
            /// <summary>
            /// Index of the deleted item before it was removed.
            /// </summary>
            public int ItemIndex { get; set; }
        }
    }
}

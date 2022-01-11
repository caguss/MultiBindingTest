using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MultiBindingTest
{
    public class AModelDataStore : IDataStore<AModel>
    {
        private List<AModel> items;

        /// <summary>
        /// 화학물질/msds/비상대응 데이터 맞추어 넣기?
        /// </summary>
        public AModelDataStore()
        {
            GetRefresh();
        }

        public async Task<bool> AddItemAsync(AModel item)
        {
            items.Add(item);

            //Provider를 통한 데이터 입력

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(AModel item)
        {
            var oldItem = items.Where((AModel arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((AModel arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<AModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<AModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public void GetRefresh()
        {
            //Provider를 통한 데이터 조회
            items = new List<AModel>()
            {

                new AModel { ID = "ID1",Category = Guid.NewGuid().ToString(), tag = "First item"},
                new AModel { ID = "ID2",Category = Guid.NewGuid().ToString(), tag = "Second item" },
                new AModel { ID = "ID3",Category = Guid.NewGuid().ToString(), tag = "Third item"},
                new AModel { ID = "ID4",Category = Guid.NewGuid().ToString(), tag = "Fourth item" },
                new AModel { ID = "ID5",Category = Guid.NewGuid().ToString(), tag = "Fifth item"},
                new AModel { ID = "ID6",Category = Guid.NewGuid().ToString(), tag = "Sixth item"}
            };
        }
    }

}
//------------------------------------------------------------------------------------------------------------------------------------
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
//------------------------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ws3dx.core.exception;
using ws3dx.dsmfg;
using ws3dx.dsmfg.data;
using ws3dx.dsmfg.data.impl;
using ws3dx.dsmfg.data.model;
using ws3dx.dsmfg.service;
using ws3dx.utils.search;

namespace NUnitTestProject
{
    public class MfgItemService_MfgItem_UnitTests : MfgItemServiceTestsSetup
    {
        [TestCase("AAA27", 0, 50)]
        public async Task Search_Paged_IMfgItemMask(string search, int skip, int top)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, skip, top);



            Assert.IsNotNull(ret);
        }

        [TestCase("AAA27")]
        public async Task Search_Full_IMfgItemMask(string search)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(search);

            IEnumerable<IMfgItemMask> ret = await mfgItemService.Search<IMfgItemMask>(searchByFreeText);

            Assert.IsNotNull(ret);
        }

        [TestCase("AAA27", 0, 10)]
        public async Task Get_IMfgItemMask(string _search, int _skip, int _top)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IMfgItemMask> mfgItemSearchResult = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, _skip, _top);

            string[] mfgItemIdArray = mfgItemSearchResult.Select(mfgItem => mfgItem.Id).ToArray<string>();

            foreach (string mfgItemId in mfgItemIdArray)
            {
                IMfgItemMask ret = await mfgItemService.Get<IMfgItemMask>(mfgItemId);

                Assert.IsNotNull(ret);
            }
        }


        [TestCase("AAA27", 0, 10)]
        public async Task Get_IMfgItemDetailMask(string _search, int _skip, int _top)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

            IEnumerable<IMfgItemMask> mfgItemSearchResult = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, _skip, _top);

            string[] mfgItemIdArray = mfgItemSearchResult.Select(mfgItem => mfgItem.Id).ToArray<string>();

            foreach (string mfgItemId in mfgItemIdArray)
            {
                IMfgItemDetailMask ret = await mfgItemService.Get<IMfgItemDetailMask>(mfgItemId);

                Assert.IsNotNull(ret);

                TestSubType(ret);
            }
        }


        void TestSubType(IMfgItemDetailMask _mfgItem)
        {
            if (string.Equals(_mfgItem.Type, MFGResourceNames.MANUFACTURED_MATERIAL_TYPE))
            {
                IManufacturedMaterial manufacturedMaterial = (IManufacturedMaterial)_mfgItem;
                Assert.IsNotNull(manufacturedMaterial);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MANUFACTURING_ASSEMBLY_TYPE))
            {
                IManufacturingAssembly manufacturingAssembly = (IManufacturingAssembly)_mfgItem;
                Assert.IsNotNull(manufacturingAssembly);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.PROVIDED_PART_TYPE))
            {
                IProvidedPart providedPart = (IProvidedPart)_mfgItem;
                Assert.IsNotNull(providedPart);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MANUFACTURED_PART_TYPE))
            {
                IManufacturingPart manufacturingPart = (IManufacturingPart)_mfgItem;
                Assert.IsNotNull(manufacturingPart);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MANUFACTURING_INSTALLATION_TYPE))
            {
                IInstallation installation = (IInstallation)_mfgItem;
                Assert.IsNotNull(installation);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MANUFACTURING_KIT_TYPE))
            {
                IManufacturingKit mfgKit = (IManufacturingKit)_mfgItem;
                Assert.IsNotNull(mfgKit);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.PROC_CONT_MANUF_MAT_TYPE))
            {
                IContinuousManufacturedMaterial continuousManufacturedMaterial = (IContinuousManufacturedMaterial)_mfgItem;
                Assert.IsNotNull(continuousManufacturedMaterial);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.PROC_CONT_PROVIDED_PART_TYPE))
            {
                IContinuousProvidedMaterial continuousManufacturedMaterial = (IContinuousProvidedMaterial)_mfgItem;
                Assert.IsNotNull(continuousManufacturedMaterial);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.FASTEN_TYPE))
            {
                IFasten fasten = (IFasten)_mfgItem;
                Assert.IsNotNull(fasten);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MARKING_TYPE))
            {
                IMarking marking = (IMarking)_mfgItem;
                Assert.IsNotNull(marking);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.PRE_DRILL_TYPE))
            {
                IPreDrill preDrill = (IPreDrill)_mfgItem;
                Assert.IsNotNull(preDrill);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.DRILL_TYPE))
            {
                IDrill drill = (IDrill)_mfgItem;
                Assert.IsNotNull(drill);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.ANNOTATION_TYPE))
            {
                IAnnotation annotation = (IAnnotation)_mfgItem;
                Assert.IsNotNull(annotation);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.BEVELING_TYPE))
            {
                IBeveling beveling = (IBeveling)_mfgItem;
                Assert.IsNotNull(beveling);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.CUTTING_TYPE))
            {
                ICutting cutting = (ICutting)_mfgItem;
                Assert.IsNotNull(cutting);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.GRINDING_TYPE))
            {
                IGrinding grinding = (IGrinding)_mfgItem;
                Assert.IsNotNull(grinding);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.NODRILL_TYPE))
            {
                INoDrill noDrill = (INoDrill)_mfgItem;
                Assert.IsNotNull(noDrill);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.MACHINE_TYPE))
            {
                IMachine machine = (IMachine)_mfgItem;
                Assert.IsNotNull(machine);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.TRANSFORM_TYPE))
            {
                ITransform transform = (ITransform)_mfgItem;
                Assert.IsNotNull(transform);
                return;
            }

            if (string.Equals(_mfgItem.Type, MFGResourceNames.UNFASTEN_TYPE))
            {
                IUnfasten transform = (IUnfasten)_mfgItem;
                Assert.IsNotNull(transform);
                return;
            }

            throw new System.Exception($"Unhandled type '{_mfgItem.Type}'");
        }


        [TestCase("AAA27 Manufacturing Configuration Item", "A.1")]
        public async Task Expand(string _title, string _rev)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            try
            {
                SearchByTitleRevision searchCriteria = new SearchByTitleRevision(_title, _rev);

                IEnumerable<IMfgItemMask> mfgItemSearchResult = await mfgItemService.Search<IMfgItemMask>(searchCriteria);

                foreach (IMfgItemMask mfgItem in mfgItemSearchResult)
                {
                    MfgItemExpandRequestPayloadV1 expand = new MfgItemExpandRequestPayloadV1
                    {
                        ExpandDepth = -1,
                        WithPath = true
                    };

                    IEnumerable<object> ret = await mfgItemService.Expand(mfgItem.Id, expand);
                    Assert.IsNotNull(ret);
                }
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase(MFGResourceNames.MANUFACTURING_ASSEMBLY_TYPE, "AAA27 Mfg Assembly Test 1", "New Mfg Assembly from Web Services")]
        public async Task Create_IMfgItemDetailMask(string _type, string _title, string _description)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            INewMfgItem newMfgItem = new NewMfgItem
            {
                Attributes = new MfgItem()
            };
            newMfgItem.Attributes.Type = _type;
            newMfgItem.Attributes.Title = _title;
            newMfgItem.Attributes.Description = _description;

            ICreateMfgItems request = new CreateMfgItems
            {
                Items = [newMfgItem]
            };

            try
            {
                IEnumerable<IMfgItemMask> ret = await mfgItemService.Create<IMfgItemMask>(request);
                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("AAA27", 0, 25)]
        public async Task Bulkfetch_IMfgItemDetailMask(string _search, int _skip, int _top)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            try
            {
                SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

                IEnumerable<IMfgItemMask> mfgItemSearchResult = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, _skip, _top);

                string[] mfgItemIdArray = mfgItemSearchResult.Select(mfgItem => mfgItem.Id).ToArray<string>();

                IList<string> errorIdList = null;

                IEnumerable<IMfgItemDetailMask> returnSetWithDetailMask = null;

                (returnSetWithDetailMask, errorIdList) = await mfgItemService.BulkFetch<IMfgItemDetailMask>(mfgItemIdArray);

                Assert.IsNotNull(returnSetWithDetailMask);

            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        [TestCase("AAA27", 0, 25)]
        public async Task Bulkfetch_IMfgItemMask(string _search, int _skip, int _top)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            try
            {
                SearchByFreeText searchByFreeText = new SearchByFreeText(_search);

                IEnumerable<IMfgItemMask> mfgItemSearchResult = await mfgItemService.Search<IMfgItemMask>(searchByFreeText, _skip, _top);

                string[] mfgItemIdArray = mfgItemSearchResult.Select(mfgItem => mfgItem.Id).ToArray<string>();

                IList<string> errorIdList = null;

                IEnumerable<IMfgItemMask> returnSetWithMask = null;

                (returnSetWithMask, errorIdList) = await mfgItemService.BulkFetch<IMfgItemMask>(mfgItemIdArray);

                Assert.IsNotNull(returnSetWithMask);

            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        //TODO
        [TestCase()]
        public async Task LocateMethod1(int top, int skip)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            ILocateMfgItemsRequest request = new LocateMfgItemsRequest();

            try
            {
                IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(top, skip, request);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }

        //TODO
        [TestCase()]
        public async Task LocateMethod2(int top, int skip)
        {
            MfgItemService mfgItemService = ServiceFactoryCreate(await Authenticate());

            ILocateMfgItems request = new LocateMfgItems();

            try
            {
                IEnumerable<ILocateMfgItemsResponse> ret = await mfgItemService.Locate(top, skip, request);

                Assert.IsNotNull(ret);
            }
            catch (HttpResponseException _ex)
            {
                string errorMessage = await _ex.GetErrorMessage();
                Assert.Fail(errorMessage);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahilBorsasi.Repository;

namespace TahilBorsa.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;

        private AddressRepository addressRepository;
        private CityRepository cityRepository;
        private DistrictRepository districtRepository;
        private EntryProductRepository entryProductRepository;
        private FarmerRepository farmerRepository;
        private LabDataRepository labDataRepository;
        private ProductNameRepository productNameRepository;
        private SaleRepository saleRepository;
        private TradesmanRepository tradesmanRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public AddressRepository AddressRepository
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(context);
                return addressRepository;
            }
        }

        public CityRepository CityRepository
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(context);
                return cityRepository;
            }
        }

        public DistrictRepository DistrictRepository
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new DistrictRepository(context);
                return districtRepository;
            }
        }

        public EntryProductRepository EntryProductRepository
        {
            get
            {
                if (entryProductRepository == null)
                    entryProductRepository = new EntryProductRepository(context);
                return entryProductRepository;
            }
        }

        public FarmerRepository FarmerRepository
        {
            get
            {
                if (farmerRepository == null)
                    farmerRepository = new FarmerRepository(context);
                return farmerRepository;
            }
        }

        public LabDataRepository LabDataRepository
        {
            get
            {
                if (labDataRepository == null)
                    labDataRepository = new LabDataRepository(context);
                return labDataRepository;
            }
        }

        public ProductNameRepository ProductNameRepository
        {
            get
            {
                if (productNameRepository == null)
                    productNameRepository = new ProductNameRepository(context);
                return productNameRepository;
            }
        }

        public SaleRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository(context);
                return saleRepository;
            }
        }

        public TradesmanRepository TradesmanRepository
        {
            get
            {
                if (tradesmanRepository == null)
                    tradesmanRepository = new TradesmanRepository(context);
                return tradesmanRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

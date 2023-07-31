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

        private AddressRepository? addressRepository;
        private CityRepository? cityRepository;
        private DistrictRepository? districtRepository;
        private EntryProductRepository? entryProductRepository;
        private FarmerRepository? farmerRepository;
        private LabaratuarRepository? labaratuarRepository;
        private ProductRepository? productRepository;
        private SaleRepository? saleRepository;
        private TradesmanRepository? tradesmanRepository;

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

        public LabaratuarRepository LabDataRepository
        {
            get
            {
                if (labaratuarRepository == null)
                    labaratuarRepository = new LabaratuarRepository(context);
                return labaratuarRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(context);
                return productRepository;
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

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using DevelopmentTest.Business.Services.Interface;
using DevelopmentTest.Model.Factory;

namespace FacilityService.API.DependencyResolution
{
    using AutoMapper;
    using DevelopmentTest.Business.Services.Implementation;
    using DevelopmentTest.Utility.RequestTools.Implementation;
    using DevelopmentTest.Utility.RequestTools.Interface;
    using StructureMap;

    /// <summary>
    /// 
    /// </summary>
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        /// <summary>
        /// 
        /// </summary>
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            #region Infrastructure 

            For<IMapper>().Use(() => Mapper.Instance);
            For<IRequestTools>().Use<RequestTools>();
            For<IFactory>().Use<Factory>();

            #endregion

            #region Services 

            For<IEmployeeService>().Use<EmployeeService>();

            #endregion

        }
        #endregion
    }
}
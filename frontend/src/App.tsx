import { useContext, lazy, Suspense } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./components/navbar/Navbar";
import { Routes, Route } from "react-router-dom";
import CustomLinearLoader from "./components/CustomLinearLoader/CustomLinearLoader";

const Home = lazy(() => import('./pages/home/home'));
const Companies = lazy(() => import('./pages/companies/Companies'));
const AddCompany = lazy(() => import("./pages/companies/AddCompany"));
const Jobs = lazy(() => import("./pages/jobs/Jobs"));
const AddJob = lazy(() => import("./pages/jobs/AddJob"));

const App = () => {
  const { darkMode } = useContext(ThemeContext);
  const appStyle = darkMode ? "app dark" : "app";
  return (
    <div className={appStyle}>
      <Navbar></Navbar>
      <div className='wrapper'>
        <Suspense fallback={ <CustomLinearLoader />}>
          <Routes>
            <Route path="/" element={ <Home /> } />
            <Route path="/companies">
              <Route index element={ <Companies /> } />
              <Route path='add' element={ <AddCompany /> } />
            </Route>
            <Route path="/jobs">
              <Route index element={ <Jobs /> } />
              <Route path='add' element={ <AddJob /> } />
            </Route>
          </Routes>
        </Suspense>     
      </div>
    </div>
  )
  
};

export default App;

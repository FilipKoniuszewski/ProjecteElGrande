
import {Route, Routes} from "react-router-dom";
import Layout from "./components/Layout";
import './App.css';
import WelcomePage from "./components/WelcomePage/WelcomePage";
import ProfilePage from "./components/profilePage/ProfilePage"
import RegisterForm from "./components/Register/RegisterForm";
import EventForm from "./components/Event/EventForm";


function App() {
  return (
      <Routes>
        <Route path="/" element={<Layout/>}>
            <Route index element={< WelcomePage />}/>
            <Route path="home" element={<WelcomePage />}/>
            <Route path="profile" element={<ProfilePage />}/>
              <Route path="home" element={<WelcomePage />} />
              <Route path="register" element={<RegisterForm />} />
            <Route path="event/create" element={<EventForm />} />
        </Route>
      </Routes>
  );
}
export default App;

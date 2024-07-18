import ButtonCreate from "../atoms/ButtonCreate";
import HrefNavbarMenu from "../atoms/HrefNavbarMenu";
import ImgNavbarLogo from "../atoms/ImgNavbarLogo";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { CgProfile } from "react-icons/cg";

const NavbarMain = ({ history }) => {
    const [loginUser, setLoginUser] = useState(false);
    const navigate = useNavigate();
    const handleNavigateOnCreateQuestion = () => navigate(`/question/create`);
    const handleNavigateOnEditUser = () => navigate(`/user/edit`);
    const handleNavigateHome = () => navigate(`/`);
    const handleLogout = () => {
        setLoginUser(false);
        localStorage.removeItem("authToken");
        navigate("/login");
    }

    useEffect(() => {
        if (localStorage.getItem("authToken")) {
            setLoginUser(true);
        }
    }, [history]);

  return (
      <nav className="navbar navbar-expand-lg navbar-light p-0">
          <div className="container-fluid">
              <ImgNavbarLogo src="/logo.png" onClick={handleNavigateHome}></ImgNavbarLogo>
              <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span className="navbar-toggler-icon"></span>
              </button>
              <div className="collapse navbar-collapse" id="navbarSupportedContent">
                  <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                      <li className="nav-item">
                          <HrefNavbarMenu className="nav-link active" aria-current="page" href="/">Home</HrefNavbarMenu>
                      </li>
                  </ul>
                  <div className="">
                      <ul className="navbar-nav mr-auto">
                          <li className="nav-item active">
                              {loginUser && <HrefNavbarMenu className="nav-link" onClick={handleNavigateOnEditUser}><CgProfile className="icon-profile" /></HrefNavbarMenu>}
                          </li>
                          <li className="nav-item active">
                              {loginUser ? <HrefNavbarMenu className="nav-link mt-1" onClick={handleLogout}>Log&nbsp;out</HrefNavbarMenu> : <HrefNavbarMenu className="nav-link" href="/login">Sign&nbsp;in</HrefNavbarMenu>}
                          </li>
                          <li className="nav-item active">
                              {loginUser && <ButtonCreate className="mt-1" style={{ marginRight: 20 }} onClick={handleNavigateOnCreateQuestion}>Create question</ButtonCreate>}
                          </li>
                      </ul>                
                  </div>
              </div>
          </div>
      </nav>
  );
};

export default NavbarMain;

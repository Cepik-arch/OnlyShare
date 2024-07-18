import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";

import { Routes, Route } from "react-router-dom";
import CreateQuestionPage from "./pages/Question/CreateQuestionPage";
import MainPage from "./pages/MainPage";
import DetailQuestionPage from "./pages/Question/DetailQuestionPage";
import ForgotPasswordPage from "./pages/ForgotPasswordPage";
import EditUserPage from "./pages/EditUserPage";
import ResetPasswordPage from "./pages/ResetPasswordPage";
import EditQuestionPage from "./pages/Question/EditQuestionPage";
import EditAnswerPage from "./pages/Answer/EditAnswerPage";


const AppRoutes = () => (
    <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/forgot-password" element={<ForgotPasswordPage />} />
        <Route path="/reset-password/:resetToken" element={<ResetPasswordPage />} />

        <Route path="/user/edit" element={<EditUserPage />} />
        <Route path="/question/create" element={<CreateQuestionPage />} />
        <Route path="/question/detail/:id" element={<DetailQuestionPage />} />
        <Route path="/question/edit/:id" element={<EditQuestionPage />} />

        <Route path="/answer/edit/:id" element={<EditAnswerPage />} />

    </Routes>
);
export default AppRoutes;   

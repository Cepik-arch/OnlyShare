import ButtonCreate from "../atoms/ButtonCreate";
import TextCorrectMessage from "../atoms/TextCorrectMessage";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextFirstSectionTitle from "../atoms/TextFirstSectionTitle";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import InputWithTitle from "../molecules/InputWithTitle";
import { FormWrapper } from "./styles";

const EditUserPageTemplate = ({
    error,
    success,
    handleUsernameChange,
    handlePasswordChange,
    handlePasswordRepeatChange,
    handleCurrentPasswordChange,
    handleEditUserName,
    handleChangePassword,
    username,
    email,
    password,
    passwordRepeat,
    currentPassword,
}) => {
    return (
        <>
            <div className="container">
                <div className="row">
                    <div className="col-md-12 d-flex justify-content-center mb-0">
                        <TextMainTitle>OnlyShare</TextMainTitle>
                    </div>
                    <div className="col-md-12 d-flex justify-content-center my-0">
                        <TextMainSubTitle>Ask and Share</TextMainSubTitle>
                    </div>
                </div>
            </div>
            <FormWrapper>
                <div className="container">
                    {error
                        &&
                        <div className="row d-flex justify-content-center">
                            <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                        </div>
                    }
                    {success
                        &&
                        <div className="row d-flex justify-content-center">
                            <TextCorrectMessage className="mt-3">{success}</TextCorrectMessage>
                        </div>
                    }
                    <div className="row d-flex justify-content-center">
                        <TextFirstSectionTitle>{email}</TextFirstSectionTitle>
                    </div>
                    <div className="row">
                        <div className="col-md-6">
                            <form onSubmit={handleEditUserName}>
                                <div className="row d-flex justify-content-center">
                                    <InputWithTitle
                                        title={"Username"}
                                        placeholder={"Username..."}
                                        value={username}
                                        onChange={handleUsernameChange}
                                        type={"text"}
                                    />
                                </div>
                                <div className="row d-flex justify-content-center">
                                    <ButtonCreate type="submit" style={{ marginTop: 30 }}>Edit username</ButtonCreate>
                                </div>
                            </form>
                        </div>
                        <div className="col-md-6">
                            <form onSubmit={handleChangePassword}>
                                <div className="row d-flex justify-content-center">
                                    <InputWithTitle
                                        title={"Old password"}
                                        placeholder={"Old password..."}
                                        value={currentPassword}
                                        onChange={handleCurrentPasswordChange}
                                        type={"password"}
                                    />
                                </div>
                                <div className="row d-flex justify-content-center">
                                    <InputWithTitle
                                        title={"New password"}
                                        placeholder={"New password..."}
                                        value={password}
                                        onChange={handlePasswordChange}
                                        type={"password"}
                                    />
                                </div>
                                <div className="row d-flex justify-content-center">
                                    <InputWithTitle
                                        title={"Confirm new password"}
                                        placeholder={"Confirm new password..."}
                                        value={passwordRepeat}
                                        onChange={handlePasswordRepeatChange}
                                        type={"password"}

                                    />
                                </div>
                                <div className="row d-flex justify-content-center">
                                    <ButtonCreate type="submit" style={{ marginTop: 30 }}>Change password</ButtonCreate>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </FormWrapper>
        </>
    );
};

export default EditUserPageTemplate;

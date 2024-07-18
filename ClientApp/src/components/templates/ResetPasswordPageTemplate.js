import ButtonCreate from "../atoms/ButtonCreate";
import TextErrorMessage from "../atoms/TextErrorMessage";
import TextMainSubTitle from "../atoms/TextMainSubTitle";
import TextMainTitle from "../atoms/TextMainTitle";
import InputWithTitle from "../molecules/InputWithTitle";
import { FormWrapper } from "./styles";

const ResetPasswordPageTemplate = ({
    error,
    handlePasswordChange,
    handleConfirmPasswordChange,
    handleResetPassword,
    confirmPassword,
    password,
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
                    <form onSubmit={handleResetPassword}>
                        {error
                            &&
                            <div className="row d-flex justify-content-center">
                                <TextErrorMessage className="mt-3">{error}</TextErrorMessage>
                            </div>
                        }
                        <div className="row d-flex justify-content-center">
                            <InputWithTitle
                                title={"Password"}
                                placeholder={"Password..."}
                                value={password}
                                onChange={handlePasswordChange}
                                type={"password"}
                            />
                        </div>
                        <div className="row d-flex justify-content-center">
                            <InputWithTitle
                                title={"Confirm password"}
                                placeholder={"Confirm password..."}
                                value={confirmPassword}
                                onChange={handleConfirmPasswordChange}
                                type={"password"}
                            />
                        </div>
                        <div className="row d-flex justify-content-center">
                            <ButtonCreate type="submit" style={{ marginTop: 30 }}>Reset password</ButtonCreate>
                        </div>
                    </form>
                </div>
            </FormWrapper>
        </>
    );
};

export default ResetPasswordPageTemplate;

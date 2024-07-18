
import TextAnswerTitle from "../atoms/TextAnswerTitle";
import { CardAnswerBottomWrapper } from "./styles";

const CardAnswerBottom = () => {
    return (
        <CardAnswerBottomWrapper>
            <div className="row text-center">
                <div className="col-md-12">
                    <TextAnswerTitle>Approved</TextAnswerTitle>
                </div>
            </div>
        </CardAnswerBottomWrapper>
    );
};

export default CardAnswerBottom;
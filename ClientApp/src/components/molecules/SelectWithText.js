import OptionTag from "../atoms/OptionTag";
import SelectBoxTag from "../atoms/SelectBoxTag";
import TextForm from "../atoms/TextForm";
import { InputWrapper } from "./styles";
import { AiOutlinePlusCircle, AiFillDelete } from "react-icons/ai";
import TextAnswerTitle from "../atoms/TextAnswerTitle";

const SelectWithText = ({
    tags,
    title,
    handleSelectTagChanged,
    handleAddSelectTag,
    selectTag,
    selectTags,
    handleDeleteSelectTag,
}) => {
    return (
        <InputWrapper>
            <div className="col-md-12 mb-0">
                <TextForm>{title}</TextForm>
            </div>
            <div className="row">
                <div className="col-md-9 mb-0">
                    <SelectBoxTag value={selectTag} onChange={handleSelectTagChanged}>
                        {tags
                            .sort((a, b) => a.localeCompare(b))
                            .map(tag => (
                                <OptionTag key={tag}>{tag}</OptionTag>
                            ))}
                    </SelectBoxTag>

                </div>
                <div className="col-md-3 mb-0">
                    <AiOutlinePlusCircle className="icon-add-tag" onClick={handleAddSelectTag} />
                </div>
            </div>
            <div className="row">

                        {selectTags.length != 0
                        ? <>
                            {selectTags
                            .map(tag => (
                                <div className="row m-0 p-0" key={tag}>
                                        <div className="col-md-12 mb-0">
                                        <AiFillDelete className="icon-delete-tag" onClick={() => handleDeleteSelectTag(tag)} />
                                        <TextAnswerTitle >{tag}</TextAnswerTitle>
                                            
                                        </div>
                                    </div>
                                    
                                ))}
                        </> :
                            <TextAnswerTitle>No tag has been selected</TextAnswerTitle>
                            }
            </div>
        </InputWrapper>
    );
};

export default SelectWithText;

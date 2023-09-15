import {ITaskComments} from "../../../models/ITaskComments";
import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";

export async function GetTaskCommentsServer(taskId? : string){
    return await axios.get<ITaskComments[]>(`${serverApi}/taskcomment/get/${taskId}`)
}

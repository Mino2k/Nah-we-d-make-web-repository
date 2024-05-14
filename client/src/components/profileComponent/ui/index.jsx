import styles from './styles.module.scss';
import {useContext, useState} from "react";
import UserInfoContext from "../../../contexts/UserInfoContext";
import ProfilePortfolioComponent from "./components/profilePortfolioComponent";
import ProfileBookmarkComponent from "./components/profileBookmarkComponent";
import ProfileAboutComponent from "./components/profileAboutComponent";
import AuthContext from "../../../contexts/AuthContext";
import {useNavigate, useParams} from 'react-router-dom';
import {toast} from "react-toastify";
import emptyProfilePhoto from '../../../img/emptyProfilePhoto.jpg'


const ProfileComponent = () => {
    const {username} = useParams();
    const isLogged = useContext(AuthContext);
    const userInfo = useContext(UserInfoContext);
    const [currentNavElement, setCurrentNavElement] = useState('Портфолио')
    const navigate = useNavigate();

    const handleShare = async () => {
        await navigator.clipboard.writeText(`https://pp.yakovlev05.ru/${userInfo.login}`)
        toast.success('Ссылка скопирована в буфер обмена')
    }

    return (
        <div className={styles.profile}>
            <img className={styles.image}
                 src={userInfo.profilePhoto ? `/api/v1/content/image/${userInfo.profilePhoto}` : emptyProfilePhoto}
                 alt={'avatar'}
                 width='200' height='200'/>
            <h1 className={styles.username}>{userInfo.login}</h1>
            {isLogged && (<div className={styles.containerButtons}>
                <button className={styles.button} onClick={handleShare}>Поделиться</button>
                <button className={styles.button} onClick={() => navigate('/me/edit')}>Редактировать</button>
            </div>)}
            <ul className={styles.navList}>
                <li className={styles.navElement}
                    onClick={() => setCurrentNavElement('Портфолио')}>Портфолио/
                </li>
                <li className={styles.navElement}
                    onClick={() => setCurrentNavElement('Избранное')}>Избранное
                </li>
                <li className={styles.navElement}
                    onClick={() => setCurrentNavElement('Обо мне')}>/Обо мне
                </li>
            </ul>
            {currentNavElement === 'Портфолио' && <ProfilePortfolioComponent/>}
            {isLogged && currentNavElement === 'Избранное' && <ProfileBookmarkComponent/>}
            {currentNavElement === 'Обо мне' && <ProfileAboutComponent/>}
        </div>
    )
}

export default ProfileComponent
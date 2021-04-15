package com.xhfron.paperless.dao;

import com.xhfron.paperless.bean.Option;
import com.xhfron.paperless.bean.VoteDO;
import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;

import java.util.List;

@Mapper
public interface VoteDao {

    @Insert("insert into `device_option` values(#{deviceId}, #{optionId})")
    int insertOption(int optionId, int deviceId);

    @Select("select * from `vote` where meeting_id = #{meetingId}")
    List<VoteDO> getVoteListByMeetingId(int meetingId);

    @Select("select * from `option` where belongs = #{voteId}")
    List<Option> getOptionsByVoteId(int voteId);

    @Select("select * from `device_option` where vote_id = #{voteId}")
    List<Option> getResultByVoteId(int voteId);

    @Select("select * from vote where uid =#{voteId}")
    VoteDO getVoteById(int voteId);

    @Select("select name from `device` where uid in (select device_id from `device_option` where option_id = #{optionId})")
    List<String> getDevicesByOptionId(int optionId);
}
